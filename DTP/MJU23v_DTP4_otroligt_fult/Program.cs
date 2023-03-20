namespace MJU23v_DTP4_otroligt_fult
{
    internal class Program
    {
        class Word
        {
            public string svenska { get; private set; }
            public string latin { get; private set; } 
            public Word(string svenska, string latin)
            {
                this.svenska = svenska; this.latin = latin;
            }
        }
        static void Main(string[] args)
        {
            List<Word> ordbok = new() {
                new Word("träd", "arbor"),
                new Word("huvud", "caput"),
                new Word("måne", "luna"),
                new Word("flytta", "movere"),
                new Word("pappa", "pater"),
                new Word("stad", "urbs"),
                new Word("se", "videre") };
            Console.WriteLine("Välkommen till ordlistan! Skriv 'hjälp' för hjälp!");
            string command;
            do
            {
                command = Input("> ");
                // exekvera kommandot här
                if (command == "sluta") 
                {
                    Console.WriteLine("Adjö!");
                }
                else if (command == "hjälp")
                {
                    ShowHelp();
                }
                else if (command == "latin")
                {
                    Latin(ordbok, Input("Ange latinskt ord: "));
                }
                else if (command == "ny")
                {
                    NewWord(ordbok);
                }
                else if (command == "svenska")
                {
                    Svenska(ordbok, "Ange svenskt ord: ");
                }
                else if (command == "ta bort")
                {
                    RemoveWord(ordbok);
                }
                else if (command == "visa")
                {
                    ShowDictionary(ordbok);
                }
                else
                {
                    Console.WriteLine($"Okänt kommando '{command}'");
                }
            } while (command != "sluta");
        }

        private static void ShowDictionary(List<Word> ordbok)
        {
            for (int i = 0; i < ordbok.Count; i++)
                Console.WriteLine(" {0} - {1}", ordbok[i].latin, ordbok[i].svenska);
        }

        private static void RemoveWord(List<Word> ordbok)
        {
            for (int i = 0; i < ordbok.Count; i++)
                Console.WriteLine(i + ": " + ordbok[i].latin + " - " + ordbok[i].svenska);
            int index;
            while (!int.TryParse(Input("Vilket index vill du ta bort (-1 för att avbryta): "), out index)) ;
            if (index >= 0 && index < ordbok.Count) ordbok.RemoveAt(index);
            else Console.WriteLine("Felaktigt index.");
        }

        private static void NewWord(List<Word> ordbok)
        {
            Console.WriteLine("Ange en ny glosa");
            string svensk_betydelse = Input("svenska: ");
            string latinsk_betydelse = Input("latin: ");
            int i;
            ordbok.Add(new Word(svensk_betydelse, latinsk_betydelse));
        }

        private static void Latin(List<Word> ordbok, string latinskGlosa)
        {
            for (int i = 0; i < ordbok.Count; i++)
            {
                if (ordbok[i].latin == latinskGlosa)
                {
                    Console.WriteLine($"Svensk översättning: {ordbok[i].svenska}");
                }
            }
        }
        private static void Svenska(List<Word> ordbok, string svenskGlosa)
        {
            for (int i = 0; i < ordbok.Count; i++)
            {
                if (ordbok[i].svenska == svenskGlosa)
                {
                    Console.WriteLine($"Latinsk översättning: {ordbok[i].latin}");
                }
            }
        }

        private static void ShowHelp()
        {
            Console.WriteLine("hjälp        visa en lista på alla kommandon och en förklaring");
            Console.WriteLine("latin        slå upp ett svenskt ord och få den latinska översättningen");
            Console.WriteLine("ny           programmet frågar efter latin sedan svenska, uppslaget läggs in i ordlistan");
            Console.WriteLine("sluta        programmet avslutas");
            Console.WriteLine("svenska      slå upp ett latinskt ord och få den svenska översättningen");
            Console.WriteLine("ta bort      vi tar bort ett uppslag ur ordlistan");
            Console.WriteLine("visa         alla uppslag i ordlistan visas");
        }

        private static string Input(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
