using System.Linq.Expressions;

namespace D24_Tenta
{
    internal class Program
    {
        //Uppgift 1: Konstanter:
        const double C_IN_KMPS = 299792.458;
        const int SUN_DISTANCE_IN_KM = 149598023;
        const int SEC_PER_MIN = 60;
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
            Console.Write(
                " Oförändrat array shift + 1: ");
            PrintArray<int>(ShiftArray<int>(oneToTen, 1));
            Console.Write(
                " Oförändrat array shift - 3: ");
            PrintArray<int>(ShiftArray<int>(oneToTen, -3));
        }

        //Static-metoder:
        //Uppgift 2:
        static double InvSqr(double x)
        {
            return 1 / (x * x);
        }
        //Uppgift 3: Summan av jämna tal mellan två tal:
        static double SumEvens(int a, int b, int sum = 0)
        //SumEvens - Returns the sum of all even integers between a and b (inclusive)
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
                int newIndex = (i + shift);
                if (newIndex + 1 > ln) newIndex -= (newIndex + 1 % ln) - 1;
                else if (newIndex < 0) newIndex += ln;
                newArr[i] = arr[newIndex];
            }
            return newArr;
        }
        static void PrintArray<T>(T[] array)
        //PrintArray - Prints an array to terminal like: "{ element, element, ... element }\n"
        {
            Console.Write("{ ");
            for (int i = 0, ln = array.Length; i < ln; i++) Console.Write(array[i] + (i != ln - 1 ? ", " : " }\n"));
        }
    }
}