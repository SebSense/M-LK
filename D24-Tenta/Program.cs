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

        }
        //Uppgift 2: Static-metod:
        static double InvSqr(double x)
        {
            return 1 / (x * x);
        }
    }
}