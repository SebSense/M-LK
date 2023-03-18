namespace MJU23v_DTP4_otroligt_fult
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] svenska = { "träd", "huvud", "måne", "flytta", "pappa", "stad", "se",
                                 null, null, null, null, null, null, null, null, null, null
                               };
            string[] latin = { "arbor", "caput", "luna", "movere", "pater", "urbs", "videre",
                               null, null, null, null, null, null, null, null, null, null
                             };
            Console.WriteLine("Välkommen till ordlistan! Skriv 'hjälp' för hjälp!");
            string S;
            do
            {
                Console.Write("> ");
                S = Console.ReadLine();
                // exekvera kommandot här
                if (S == "sluta") { }
                else if (S == "hjälp")
                {
                    Console.WriteLine("hjälp        visa en lista på alla kommandon och en förklaring");
                    Console.WriteLine("latin        slå upp ett svenskt ord och få den latinska översättningen");
                    Console.WriteLine("ny           programmet frågar efter latin sedan svenska, uppslaget läggs in i ordlistan");
                    Console.WriteLine("sluta        programmet avslutas");
                    Console.WriteLine("svenska      slå upp ett latinskt ord och få den svenska översättningen");
                    Console.WriteLine("ta bort      vi tar bort ett uppslag ur ordlistan");
                    Console.WriteLine("visa         alla uppslag i ordlistan visas");
                }
                else if (S == "latin")
                {
                    Console.Write("Ange latinskt ord: ");
                    string latinskGlosa = Console.ReadLine();
                    for (int i = 0; i < latin.Length; i++)
                    {
                        if (latin[i] == latinskGlosa)
                        {
                            Console.WriteLine($"Svensk översättning: {svenska[i]}");
                        }
                    }
                }
                else if (S == "ny")
                {
                    Console.WriteLine("Ange en ny glosa");
                    Console.Write("svenska: ");
                    string sv = Console.ReadLine();
                    Console.Write("latin: ");
                    string la = Console.ReadLine();
                    int i;
                    for (i = 0; i < latin.Length; i++)
                    {
                        if (latin[i] == null) break;
                    }
                    latin[i] = la;
                    svenska[i] = sv;
                }
                else if (S == "svenska")
                {
                    Console.Write("Ange svenskt ord: ");
                    string sv = Console.ReadLine();
                    for (int i = 0; i < svenska.Length; i++)
                    {
                        if (svenska[i] == sv)
                        {
                            Console.WriteLine($"Latinsk översättning: {latin[i]}");
                        }
                    }
                }
                else if (S == "ta bort")
                {
                    for (int i = 0; i < svenska.Length; i++)
                    {
                        Console.WriteLine(i + ": " + latin[i] + " - " + svenska[i]);
                    }
                    Console.Write("Vilket index vill du ta bort: ");
                    int index = Int32.Parse(Console.ReadLine());
                    latin[index] = null;
                    svenska[index] = null;
                }
                else if (S == "visa")
                {
                    for (int i = 0; i < svenska.Length; i++)
                    {
                        if (latin[i] != null)
                            Console.WriteLine(latin[i] + " - " + svenska[i]);
                    }
                }
                else
                {
                    Console.WriteLine($"Okänt kommando '{S}'");
                }
            } while (S != "sluta");
        }
    }
}
