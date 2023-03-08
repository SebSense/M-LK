using System.Text.RegularExpressions;

namespace D22_ovn_1
{
    internal class Program
    {
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
            Regex reg = new Regex(@"\d+$");
            Match match;
            string input;
            do
            {
                Console.Write("Hur gammal är du? (år i heltal):");
                input = Console.ReadLine();
                match = reg.Match(input);
            } while (!match.Success);
            Console.WriteLine($"Du är {(ulong) (sekunderPerAr * Int32.Parse(input))} sekunder gammal");

        }
    }
}