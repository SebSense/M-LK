using System.Security.Cryptography.X509Certificates;

namespace D1_ovn_1_2
{
    internal class Program
    {
        /// <summary>
        /// Class Ordbok - en ordbok med två listor - en med svenska ord och en med latinska. Element med samma index översätts till varandra.
        /// </summary>
        public class Ordbok
        {
            private List<string> språk = new();
            private List<List<string>> ord = new();
            public Ordbok(string[] strings)
            {
                foreach (string s in strings) { språk.Add(s); }
            }
            public void AddLanguage(string lang)
            {
                språk.Add(lang);
            } 
            public void AddWord()
            {
                int i = 0;
                List<string> nyttOrd = new();
                språk.ForEach(språk => nyttOrd.Add(GetString("Ange ordet på " + språk + " :")));
                ord.Add(nyttOrd);
            }
            public void AddWordHardCode(string[] strings)
            {
                ord.Add(strings.ToList());
            }
            public void Visa()
            {
                Console.Write("\n    ");
                språk.ForEach((string s) => Console.Write(s + "\t\t"));
                Console.WriteLine("\n---------------------------------------------------------------------");
                foreach(List<string> word in ord)
                {
                    Console.Write("    ");
                    word.ForEach((string w) => Console.Write(w + (w.Length < 4 ? "\t\t\t" : (w.Length > 10 ? "\t" : "\t\t"))));
                    Console.WriteLine();
                }
            }
            public bool HasLanguage(string language)
            {
                return språk.Contains(language);
            }
            public void FindWord(string search, string language)
            {
                int index = språk.IndexOf(language);
                foreach(List<string> word in ord)
                {
                    if(word[index] == search)
                    {
                        Console.Write("\n");
                        språk.ForEach((string s) => Console.Write(s + ":\t\t"));
                        Console.WriteLine();
                        word.ForEach((string w) => Console.Write(w + (w.Length < 8 ? "\t\t" : (w.Length > 10 ? "\t" : "\t"))));
                        Console.WriteLine();
                        return;
                    }
                }
                Console.WriteLine("\nOrdet " + search + " på " + language + " finns inte i ordlistan.");
            }
            public void DeleteWord(string search)
            {
                foreach (List<string> word in ord)
                {
                    if (word.Contains(search))
                    {
                        ord.Remove(word);
                        Console.WriteLine(search + " borttaget ur orlistan.");
                        return;
                    }   
                }
                Console.WriteLine("\nOrdet " + search + " finns inte i ordlistan.");
            }
        }
        public class Ord
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Ordbok ordbok = new(new string[]{ "latin", "svenska" });
            ordbok.AddWordHardCode(new string[] { "annum", "år" });
            Welcome();
            string input;
            string[] words;
            while(true)
            {
                Console.Write(":");
                input = Console.ReadLine();
                words = input.Split(' ');
                if (input == "hjälp")
                {
                    Help();
                }
                else if (input == "ny")
                {
                    ordbok.AddWord();
                }
                else if (input == "sluta")
                {
                    Console.WriteLine("Adjö!");
                    return;
                }
                else if (input == "ta bort")
                {
                    ordbok.DeleteWord(GetString("Ta bort vilket ord? :"));
                }
                else if (input == "visa")
                {
                    ordbok.Visa();
                }
                else if (ordbok.HasLanguage(input))
                {
                    Console.Write("Slår upp ord på " + input + ". Ange ord: ");
                    ordbok.FindWord(Console.ReadLine(), input);

                }
            }
        }
        /// <summary>
        /// Print welcome message to console.
        /// </summary>
        static void Welcome()
        {
            Console.WriteLine("Välkommen till den latinsk-svenska ordboken. Skriv 'hjälp' för att lista kommandon.\n");
        }
        /// <summary>
        /// Placeholder method
        /// </summary>
        static void NotImplemented()
        {
            Console.WriteLine("Command not implemented");
        }
        /// <summary>
        /// Shows a list of commands
        /// </summary>
        static void Help()
        {
            Console.WriteLine("\nLatinsk-svenska ordboken. Detta är en ordbok mellan latin och svenska. Använd följande kommandon:\n" +
                "  visa        - visar hela ordlistan\n" +
                "  ny          - lägg till ett nytt ord till ordlistan\n" +
                "  ta bort     - ta bort ett ord ur ordlistan\n" +
                "  latin       - sök efter ett ord på latin och visa översättning\n" +
                "  svenska     - sök efter ett ord på svenska och visa översättning\n" +
                "  hjälp       - visa denna hjälp\n" +
                "  sluta       - avsluta programmet\n");
        }
        static string GetString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}