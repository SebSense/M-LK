using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace D22_ovn_1
{
    internal class Program
    {
        static int GetInt(string prompt)
        {
            Regex reg = new Regex(@"\d+$");
            Match match;
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                match = reg.Match(input);
            } while (!match.Success);
            return Int32.Parse(input);
        }
        static double GetDouble(string prompt)
        {
            Regex reg = new Regex(@"\d+.*\d*");
            Match match;
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                match = reg.Match(input);
            } while (!match.Success);
            return Double.Parse(input);
        }
        static string GetString(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
            } while (input == null);
            return input;
        }
        static void Main(string[] args)
        {
            //D22-ovn-1.1 - C# deklarationer, beräkningsuttryck
            //1 - 3. Skriv ut aritmetik...:
            Console.WriteLine("{0} * {1} = {2}", 1203, 677, 1203 * 677);
            Console.WriteLine("132 / 33 = {0}, rest {1}", 132 / 33, 132 % 33);
            Console.WriteLine("132 / 33 = " + 132.0 / 33.0);

            //4 - 5. Bränsle per mil, kronor per limpa...
            float antalMil = 20.3F,
                literBensinPerMil = 0.7F,
                literBensinBränsleåtgång = literBensinPerMil * antalMil;
            Console.WriteLine("Bränsleåtgång för {0} mil med en bil som dricker {1} liter per mil är {2} liter.", antalMil, literBensinPerMil, literBensinBränsleåtgång);
            float kronorPerLimpa = 25.5F,
                kronorPerAskMargarin = 34.9F,
                kronorPerLiterMjölk = 14.5F;
            Console.WriteLine("Pris för två limpor, en ask margarin och en liter mjölk: " + (kronorPerLimpa * 2F + kronorPerAskMargarin + kronorPerLiterMjölk) + "kr.");
            //6.Seklets längd
            decimal sekunderPerAr = 60m * 60m * 24M * 365.25m;
            Console.WriteLine($"Det går {sekunderPerAr * 100m} sekunder på ett sekel.");
            //7. Ålder i år till sekunder:
            int alder = GetInt("Hur gammal är du? (antal år): ");
            Console.WriteLine($"Du är {(ulong) (sekunderPerAr * alder)} sekunder gammal");
            //D22-ovn-1.2 - if-satser
            //8. Ålder
            alder = GetInt("Hur gammal är du? (antal år): ");
            Console.WriteLine((alder > 14
                ? "Du får köra moped, "
                : "Du får inte köra moped, ") +
                (alder > 15
                ? "du får ta lätt MC-kort "
                : "du får inte ta lätt MC-kort ") +
                (alder > 17
                ? "och du får ta körkort för bil!"
                : "och du får inte ta körkort för bil!"));
            //9. Länder och kalendersystem.
            string[][] kalenderLänder = {
                new String[] { "Spanien", "Portugal", "Frankrike", "Polsk-litauiska samväldet", "Polen-litauen", "Luxembourg" },
                new String[] { "Bohemien" },
                new String[] {"Preussen" },
                new String[] {"Alsace" },
                new String[] {"Strasbourg" },
                new String[] {"Norge", "Danmark"},
                new String[] {"Storbritannien", "Irland", "Engelska imperiet", "Brittiska imperiet", "Första engeslska imperiet" },
                new String[] { "Sverige", "Finland" },
                new String[] { "Japan" },
                new String[] { "Egypten" },
                new String[] { "Korea" },
                new String[] { "Kina", "Albanien" },
                new String[] {"Lettland", "Litauen" },
                new String[] {"Bulgarien" },
                new String[] {"Osmanska riket", "Ottomanska riket"},
                new String[] {"Ukraina", "Ryssland", "Estland" },
                new String[] {"Rumänien", "Jugoslavien"},
                new String[] {"Grekland"},
                new String[] {"Turkiet"},
                new String[] {"Saudiarabien" } };
            int[] kalenderÅr = { 1582, 1584, 1610, 1648, 1682, 1700, 1752, 1753, 1873, 1875, 1896, 1912, 1915, 1916, 1917, 1918, 1919, 1923, 1926, 2016};

            Console.WriteLine("\nKalendersystem - Visar vilket år ett land övergick från det Julianska till det Gregorianska kalendersystemet.");
            string input;
            do
            {
                input = GetString("Ange land ('quit' för att avsluta): ");
                if (input == "quit") break;
                else if (input == "lista") { Array.ForEach(kalenderLänder, ar => Array.ForEach(ar, land => Console.Write(land + " "))); continue; }
                bool found = false;
                for (int i = 0, j = 0; i < kalenderLänder.Length; i++, j = 0)
                {
                    for (j = 0; j < kalenderLänder[i].Length; j++)
                    {
                        if (input == kalenderLänder[i][j])
                        {
                            found = true;
                            if (i == 6 && j > 1) j = 4;
                            else if (i == 0 && j == 4) j--;
                            break;
                        }
                    }
                    if (found) { Console.WriteLine("{0} bytte kalendersystem år {1}", kalenderLänder[i][j], kalenderÅr[i]); break; }
                }
                if (!found) Console.WriteLine("'{0}' känns inte igen som land. Försök igen.", input);
            } while (true);



        }
    }
}