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
            public void Visa()
            {
                Console.Write("\n     ");
                språk.ForEach((string s) => Console.Write(s + "\t\t"));
                Console.WriteLine("\n---------------------------------------------------------------------");
                int i = 1;
                foreach(List<string> word in ord)
                {
                    Console.Write((i < 10 ? "  " + i++ + ". " : (i < 100 ? " " + i++ + ". " : i++ + ". ")));
                    word.ForEach((string w) => Console.Write(w + (w.Length < 3 ? "\t\t\t" : (w.Length > 10 ? "\t" : "\t\t"))));
                    Console.WriteLine();
                }
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
            Ordbok ordbok = new(new string[]{ "svenska", "latin" });
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
                else if (input == "latin")
                {
                    NotImplemented();
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
                else if (input == "svenska")
                {
                    NotImplemented();
                }
                else if (input == "ta bort")
                {
                    NotImplemented();
                }
                else if (input == "visa")
                {
                    ordbok.Visa();
                }
            }
        }
        /// <summary>
        /// Print welcome message to console.
        /// </summary>
        static void Welcome()
        {
            NotImplemented();
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
            NotImplemented();
        }
        static string GetString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}