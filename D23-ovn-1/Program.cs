using System.Text;

namespace D23_ovn_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //36. Loopa genom array
            string[] trollformler = { "abra", "kadabra", "hokus", "pokus", "filiokus", "sim", "sala", "bim" };
            for (int i = 0; i < trollformler.Length; i++) { if (trollformler[i] == "sim") Console.WriteLine("36. Index för 'sim': " + i); }
            //37. Array baklänges
            int[] ettTillTio = { 1, 5, 8, 4, 3, 7, 6, 2, 10, 9 };
            Console.Write("37. { ");
            for (int i = 9; i >= 0; i--) Console.Write(ettTillTio[i] + " ");
            Console.WriteLine("}");
            //38. räkna 4:or och 5:or
            int[] task38 = { 4, 4, 4, 4, 5, 6, 7, 5, 4, 3 };
            int fyror = 0, femmor = 0;
            foreach (int n in task38)
            {
                if (n == 4) fyror++;
                else if (n == 5) femmor++;
            }
            Console.WriteLine("38. Arrayen har {0} fyror och {1} femmor.", fyror, femmor);
            //39 summa och produkt
            int summa = 0, produkt = 1;
            foreach (int n in task38)
            {
                summa += n;
                produkt *= n;
            }
            Console.WriteLine("39. Summan av alla element är {0} och produkten är {1}", summa, produkt);
            //40. Array av heltal 100 till 1
            int[] hundraTillEtt = new int[100];
            for (int i = 0; i < hundraTillEtt.Length; i++)
            {
                hundraTillEtt[i] = 100 - i;
                if (hundraTillEtt[i] != hundraTillEtt.Length - i) Console.WriteLine($"Fel på index {i}");
            }
            //41 flytta värde mellan index
            int[] nollTillNio = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, };
            for (int i = 0; i < nollTillNio.Length - 1; i++)
            {
                nollTillNio[i] = nollTillNio[i + 1];
            }
            Console.Write("41. { ");
            Array.ForEach(nollTillNio, n => Console.Write(n + " "));
            Console.WriteLine("}");
            //42.


        }
    }
}