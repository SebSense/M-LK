using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
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
            Console.WriteLine($"Du är {(ulong)(sekunderPerAr * alder)} sekunder gammal");
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
            int[] kalenderÅr = { 1582, 1584, 1610, 1648, 1682, 1700, 1752, 1753, 1873, 1875, 1896, 1912, 1915, 1916, 1917, 1918, 1919, 1923, 1926, 2016 };

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

            //10-11. Växelström/vägguttag:
            //Gör denna med få element för att spara tid...
            Console.WriteLine("\n\nVäxelström/vägguttag. Anger elinformation om länder.");
            while (true)
            {
                string uttagstyp;
                int husvolttal, frekvens;
                input = GetString("Ange land ('quit' för att avsluta) :");
                if (input == "Norge")
                {
                    uttagstyp = "F, C";
                    husvolttal = 230;
                    frekvens = 50;
                }
                else if (input == "Finland")
                {
                    uttagstyp = "F, C";
                    husvolttal = 230;
                    frekvens = 50;
                }
                else if (input == "Storbritannien")
                {
                    uttagstyp = "D, M";
                    husvolttal = 230;
                    frekvens = 50;
                }
                else if (input == "Surinam")
                {
                    uttagstyp = "F, C";
                    husvolttal = 120;
                    frekvens = 60;
                }
                else if (input == "Sverige")
                {
                    uttagstyp = "F, C";
                    husvolttal = 230;
                    frekvens = 50;
                }
                else if (input == "quit")
                    break;
                else
                {
                    Console.WriteLine("'{0}' känns inte igen som land. Giltiga länder är Norge, Storbritannien, Finland, Surinam och Sverige.", input);
                    continue;
                }
                Console.WriteLine("Elinformation för {0}:\n uttagstyp: {1}\n husvolttal = {2} V\n frekvens = {3} Hz\n", input, uttagstyp, husvolttal, frekvens);
            }

            //D22-ovn-1.3 - static-metoder (funktioner)
            //12-17:
            Console.WriteLine("12. Tria(1) = {0} Tria(2) = {1} Tria(3) = {2} Tria(4) = {3}", Tria(1), Tria(2), Tria(3), Tria(4));
            Console.WriteLine("13. Unitcirle för: 1 = {0}   2 = {1}   0 = {2}   0.5 = {3}   -2 = {4}", UnitCirle(1), UnitCirle(2), UnitCirle(0), UnitCirle(0.5), UnitCirle(-2));
            Console.WriteLine("14. Inverse(1.5) = {0} Inverse(0.75) = {1} Inverse(-2) = {2} Inverse(0) = {3}", Inverse(1.5), Inverse(0.75), Inverse(-2), Inverse(0));
            Console.WriteLine($"15. Max2(12, 10) = {Max2(12, 10)} Max2(3,-2) = {Max2(3, -2)} \n16. IsEven(9) = {IsEven(9)} IsEven(-8) = {IsEven(-8)}\n17. IsDivisible(56,8) = {IsDivisible(56, 8)} IsDivisible(91,9) = {IsDivisible(91, 9)}\n");
            //D22-ovn-1.4 - loopar
            //18. Räkna ut summan av alla tal mellan 7 och -5
            int sum = 0;
            for (int i = -5; i < 8; i++)
            {
                sum += i;
            }
            Console.WriteLine("18. Summan av alla tal mellan 7 och -5 = " + sum);
            //19:
            ulong product = 1;
            for (int i = 33; i < 45; i++)
            {
                product *= (ulong)i;
            }
            Console.WriteLine("19. Produkten av alla tal mellan 33 och 44 (inklusivt) är " + product);
            //20.
            Console.WriteLine("\n20. Produkten av alla tal mellan två heltal");
            Console.WriteLine(FactorialTwo(GetInt("Tal 1: "), GetInt("Tal 2: ")));
            //21.
            Console.WriteLine("\n21. Produkten av alla tal mellan två positiva heltal");
            Console.WriteLine(FactorialPos(GetInt("Tal 1: "), GetInt("Tal 2: ")));
            //22.
            Console.WriteLine("\n22. Produkten av alla udda tal mellan två heltal:");
            Console.WriteLine(FactorialOdd(GetInt("Tal 1: "), GetInt("Tal 2: ")));
            //23.
            Console.WriteLine("\n23. Summan av X + (X+1)...+Z där beräkningen avbryts när summan > 100.");
            int[] sum100s = Sum100(GetInt("Ange tal: "));
            Console.WriteLine($"Z = {sum100s[0]} Summa = {sum100s[1]}");
            //24.
            Console.WriteLine("\n24. Summan av X + (X+1)...+Z där beräkningen avbryts en iteration innan summan > 100.");
            int[] sumBefore100s = SumBefore100(GetInt("Ange tal: "));
            Console.WriteLine($"Z = {sumBefore100s[0]} Summa = {sumBefore100s[1]}");
            //25.
            Console.WriteLine("\n25. Summan av 1/m + 1/(m+1) .... + 1/(n-1) + 1/n ");
            Console.WriteLine(SumOfInverse(GetInt("Ange m: "), GetInt("Ange n: ")));
            //26
            Console.WriteLine("\n26. Inverser av alla heltal 1, 2... n.");
            Console.WriteLine(SumOfInversesUpTo(GetInt("Ange n :")));
            //27.
            Console.WriteLine("\n27. Sign(-23) = {0} | Sign(0) = {1} | Sign(2) = {2}", Sign(-23), Sign(0), Sign(2));
            //28.
            Console.WriteLine("\n28. Abs(-32.2) = " + Abs(-32.2) + " Abs(0) = " + Abs(0) + " Abs(3.2) = " + Abs(3.2));
            //29
            Console.WriteLine("\n29. IsPrime(58) = " + IsPrime(58) + " IsPrime(59) = " + IsPrime(59));
            //30
            Console.WriteLine("\n30. Factorial. 1*2*3....*n = ?2");
            Console.WriteLine(Factorial(GetInt("Ange n: ")));
            //31
            string runZodiac;
            do
            {
                runZodiac = GetString("Run Zodiac() method? (y/n) :");
                if (runZodiac == "y") Console.WriteLine("Ditt sjärntäcken är " + Zodiac());
            } while (runZodiac != "n");

        }
        static int Tria(int x) // 12. Tria.
        {
            return (x * x + x) / 2;
        }
        static double UnitCirle(double x) //13.
        {
            return Math.Sqrt(1 - x * x);
        }
        static double Inverse(double x) //14
        {
            return 1 / x;
        }
        static int Max2(int x, int y) //15
        {
            return x > y ? x : y;
        }
        static int Min2(int x, int y)
        {
            return x < y ? x : y;
        }
        static bool IsEven(int n) //16
        {
            return n % 2 == 0 ? true : false;
        }
        static bool IsDivisible(int m, int n) //17
        {
            return m % n == 0 ? true : false;
        }
        static long FactorialTwo(int x, int y) //21
        {
            // if (x < 1) x = 1;
            // if (y < 1) y = 1;
            long fact = 1,
                hi = (long)Max2(x, y),
                lo = x < y ? (long)x : (long)y;
            while (lo <= hi) fact *= lo++;
            return fact;
        }
        static ulong FactorialPos(int x, int y) //21
        {
            if (x < 1) x = 1;
            if (y < 1) y = 1;
            ulong fact = 1,
                hi = (ulong)Max2(x, y),
                lo = x < y ? (ulong)x : (ulong)y;
            while (lo <= hi) fact *= lo++;
            return fact;
        }
        static long FactorialOdd(int x, int y) //22
        {
            // if (x < 1) x = 1;
            // if (y < 1) y = 1;
            long fact = 1,
                hi = (long)Max2(x, y),
                lo = x < y ? (long)x : (long)y;
            while (lo <= hi) fact *= IsEven((int)lo++) ? 1 : lo - 1;
            return fact;
        }
        static int[] Sum100(int x) //23
        {
            int sum = 0;
            do
            {
                sum += x++;
            } while (sum < 100);
            return new int[] { x - 1, sum };
        }
        static int[] SumBefore100(int x) //24
        {
            int sum = 0;
            do
            {
                sum += x;
            } while (sum + x++ < 100);
            return new int[] { x - 1, sum};
        }
        static double SumOfInverse(int m, int n) //25
        {
            double sum = 0;
            int lo = Min2(m, n), hi = Max2(m, n);
            while (lo <= hi) sum += Inverse(lo++);
            return sum;
        }
        static double SumOfInversesUpTo(int n) //26
        {
            double sum = 0;
            int lo = 1;
            while (lo <= n) sum += Inverse(lo++);
            return sum;
        }
        static int Sign(double x) //27
        {
            if (x == 0) return 0;
            return x < 0 ? -1 : 1;
        }
        static double Abs(double x) //28
        {
            return x < 0 ? -1 * x : x;
        }
        static bool IsPrime(int n) //29
        {
            for(int i = 2; i < n; i++)
            {
                if (IsDivisible(n, i)) return false;
            }
            return true;
        }
        static ulong Factorial (int n) //30
        {
            ulong sum = 1;
            for (int i = 2; i <= n; i++)
            {
                sum *= (ulong) i;
            }
            return sum;
        }
        static string Zodiac() // 31
        {
            string[] months = { "januari", "februari", "mars", "april", "maj", "juni", "juli", "augusti", "september", "oktober", "november", "december" };

            string födelsemånad = GetString("Ange födelsemånad: ");
            while (!months.Contains(födelsemånad))
            {
                födelsemånad = GetString("Ogiltig månad. Ange födelsemånad: ");
            }
            int nMonth = Array.IndexOf(months, födelsemånad) + 1,
                nDate = GetInt("Ange födelsedatum: "),
                max;
            if (new int[] { 1, 3, 5, 7, 8, 10, 12 }.Contains(nMonth)) max = 31;
            else if (nMonth == 2) max = 29;
            else max = 30;
            while(nDate > max || nDate < 1)
            {
                nDate = GetInt("Ogiltigt datum. Ange födelsedatum: ");
            }

            switch(nMonth)
            {
                case 1:
                    return nDate <= 20 ? "Stenbocken" : "Vattumannen";
                case 2:
                    return nDate <= 18 ? "Vattumannen" : "Fiskarna";
                case 3:
                    return nDate <= 20 ? "Fiskarna" : "Vädruen";
                case 4:
                    return nDate <= 20 ? "Väduren" : "Oxen";
                case 5:
                    return nDate <= 21 ? "Oxen" : "Tvillingarna";
                case 6:
                    return nDate <= 21 ? "Tvillingarna" : "Kräftan";
                case 7:
                    return nDate <= 22 ? "Kräftan" : "Lejonet";
                case 8:
                    return nDate <= 23 ? "Lejonet" : "Jungfrun";
                case 9:
                    return nDate <= 23 ? "Jungfrun" : "Vågen";
                case 10:
                    return nDate <= 23 ? "Vågen" : "Skorpionen";
                case 11:
                    return nDate <= 22 ? "Skorpionen" : "Skytten";
                case 12:
                    return nDate <= 21 ? "Skytten" : "Stenbocken";
                default:
                    return "Okänt fel.";
            }

        }
    }
}