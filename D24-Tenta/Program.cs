using System.Collections;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace D24_Tenta
{
    internal class Program
    {
        //Uppgift 1: Konstanter:
        const double C_IN_KMPS = 299792.458;
        const int SUN_DISTANCE_IN_KM = 149598023;
        const int SEC_PER_MIN = 60;
        //Uppgift 6: Species:
        class Species
        {
            public string Name { get; private set; }
            public string Genus { get; private set; }
            public string Epithet { get; private set; } //"Specific epithet" also simply known as "species"
            public List<string> Ranges { get; private set; } //Using List to keep it mutable
            public Species(string n, string g, string e, string[] r)
            {
                Name = n != null ? n : "Okänt";
                Genus = g != null ? g : "Okänt";
                Epithet = e != null ? e : "Okänt";
                Ranges = new List<string>();
                AddRangesArray(r);
            }
            public void Print() //Prints a list of all attributs for debug purposes.
            {
                Console.WriteLine("Namn: {0}\n släkte: {1}\n art: {2}\n utbredning: {3}", Name, Genus, Epithet, ListRanges());
            }
            public void PrintInformative() //Prints an informative sentence about the species. 
            {
                Console.WriteLine($"Arten {Name.ToLower()} ({Genus} {Epithet}) återfinns i {ListRanges()}.");
            }
            public string ListRanges() //Returns Ranges[] Array as a string formatted as: "element, element,... element and element"
            {
                if (Ranges.Count == 0) return "Okänd utbredning";
                if (Ranges.Count == 1) return Ranges[0];
                string str = Ranges[0];
                int ln = Ranges.Count - 1;
                for (int i = 1; i < ln; i++) str = String.Concat(str, ", ", Ranges[i]);
                return String.Concat(str, " and ", Ranges[ln]);
            }
            public void AddRange(string r)
            {
                Ranges.Add(r);
            }
            public void AddRangesList(List<string> rs)
            {
                Ranges.Concat(rs);
            }
            public void AddRangesArray(string[] rs)
            {
                Array.ForEach(rs, r => Ranges.Add(r));
            }
            public void SetRanges(List<string> rs)
            {
                Ranges = rs;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("D24-Tenta.exe - Numrerade uppgifter från tentamen\n");

            //Uppgift 1: Variabel och utskrift:
            double minutesForSunlightToReachEarth = (SUN_DISTANCE_IN_KM / C_IN_KMPS) / SEC_PER_MIN;
            Console.WriteLine("Uppgift 1: Det tar " + minutesForSunlightToReachEarth + " minuter för solens ljus att nå jorden\n");

            //Uppgift 2: Test och utskrifter:
            Console.WriteLine($"Uppgift 2: Test av 'InvSqr(double x)' static-metod:\n" +
                $" InvSqr(2) = {InvSqr(2)}\n" +
                $" InvSqr(3) = {InvSqr(3)}\n" +
                $" InvSqr(4) = {InvSqr(4)}\n" +
                $" InvSqr(5) = {InvSqr(5)}\n");

            //Uppgift 3: Test och utskrifter:
            Console.WriteLine($"Uppgift 3: Test av 'SumEvens(int a, int b)' static-metod:\n" +
                $" SumEvens(2, 10) = {SumEvens(2, 10)}\n" +
                $" SumEvens(6, 11) = {SumEvens(6, 11)}\n" +
                $" SumEvens(7, 9) = {SumEvens(7, 9)}\n");

            //Uppgift 4: Flytta element i en array:
            int[] oneToTen = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.Write("Uppgift 4: Flytta alla element i en array:\n" +
                " Oförändrat array:           ");
            PrintArray<int>(oneToTen);
            Console.Write(" Oförändrat array shift + 1: ");
            PrintArray<int>(ShiftArray<int>(oneToTen, 1));
            Console.Write(" Oförändrat array shift - 3: ");
            PrintArray<int>(ShiftArray<int>(oneToTen, -3));

            //Uppgift 5: Test av att summera inverser:
            Console.Write($"\nUppgift 5: Summera inverser:\n" +
                $" SumInverses(2, 10) = {SumInverses(2, 10)}\n" +
                $" SumInverses(6, 11) = {SumInverses(6, 11)}\n" +
                $" SumInverses(7, 9) = {SumInverses(7, 9)}\n");

            //Uppgit 6: Skapa och skriv ut instanser av klassen 'Species'
            Species[] arter = {
                new Species("Vildhäst", "Equus", "ferus", new string[] { "Mongoliet" }),
                new Species("Bergszebra", "Equus", "zebra", new string[] {"Namibien", "Sydafrika"}),
                new Species("Stäppzebra", "Equus", "quagga", new string[] {"Egypten", "Sudan", "Eritrea", "Etiopien" }),
                new Species("Afrikansk vildåsna", "Equus", "africanus", new string[] {"Egypten", "Sudan", "Eritrea", "Etiopien" })
                };
            Console.WriteLine("\nUppgift 6: Skriv ut fyra instanser av klassen 'Species':\n");
            Array.ForEach(arter, art => art.PrintInformative());
        }

        //Static-metoder:
        //Uppgift 2:
        static double InvSqr(double x)
        {
            return 1 / (x * x);
        }
        //Uppgift 3: Summan av jämna tal mellan två tal:
        static double SumEvens(int a, int b, int sum = 0)
        //SumEvens - Returns the sum of all even integers between a and b (inclusive) using recursion.
        {
            if (a % 2 == 0) sum += a;
            if (a == b) return sum;
            return a > b ? SumEvens(a - 1, b, sum) : SumEvens(a + 1, b, sum);
        }
        //Uppgift 4: Metod för att shifta en array:
        static T[] ShiftArray<T>(T[] arr, int shift)
        //ShiftArray - Shifts all elements in an array by 'shift' indexes. Loops through the edges of the array. Returns a new array.
        {
            int ln = arr.Length;
            T[] newArr = new T[ln];
            for (int i = 0; i < ln; i++)
            {
                int newIndex = i + shift;
                //modulates newIndex from base 10 to base 'ln'. Adds and subtracts 1 to account for 0-indexing
                newIndex = Rebase(newIndex + 1, ln) - 1;
                newArr[i] = arr[newIndex];
            }
            return newArr;
        }
        static int Rebase (int n, int b)
        //Modulates int n from base 10 to base 'b'
        {
            n %= b;
            return n < 1 ? n + b : n;
        }
        static void PrintArray<T>(T[] array)
        //PrintArray - Prints an array to terminal like: "{ element, element, ... element }\n"
        {
            Console.Write("{ ");
            for (int i = 0, ln = array.Length; i < ln; i++) Console.Write(array[i] + (i != ln - 1 ? ", " : " }\n"));
        }
        //Uppgift 5:
        static double SumInverses(int m, int n)
        //SumInverses - Returns the sum of the inverses (1 / int) for all integers between m and n (inclusive).
        {
            if (m == n) return 1.0 / m;
            return (m < n)
                ? (1.0 / m) + SumInverses(m + 1, n)
                : (1.0 / m) + SumInverses(m - 1, n);
        }
        static int GetInt(string prompt)
        //Gets an int from user
        {
            Regex regInt = new Regex(@"^-?\d+$");
            Match match;
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                match = regInt.Match(input);
            } while (!match.Success);
            return Int32.Parse(input);
        }
        static double GetDouble(string prompt)
        //Gets a double from user
        {
            Regex regDouble = new Regex(@"^-?\d+[.,]?(?<=[.,])\d+$");
            Match match;
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                match = regDouble.Match(input);
            } while (!match.Success);
            return Double.Parse(input.Replace('.', ','));
        }
    }
}