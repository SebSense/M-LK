using System.Text;

namespace D23_ovn_1
{
    internal class Program
    {
        class Star //49
        {
            private string Name { get; set; }
            private double Magnitude { get; set; }
            private double Distance { get; set; }
            public Star(string name, double magnitude, double distance) 
            { //50
                Name = name;
                Magnitude = magnitude;
                Distance = distance;
            }
            public Star() { this.Name = "newStar"; this.Magnitude = 0.0; this.Distance = 0.0; }
            //51:
            public void Print() { Console.WriteLine(" Proper name: {0}\n  Visual magnitude: {1}\n  Distance: {2} lightyears", this.Name, this.Magnitude, this.Distance); } 
        }
        //42. "Random" object
        static Random rand = new Random();
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
            int ARRSIZE = 1000;
            int[] rArr = new int[ARRSIZE];
            for (int i = 0; i < ARRSIZE; i++)
            {
                rArr[i] = rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7);
            }
            //Array.ForEach(rArr, n =>Console.Write(n + " "));
            //43.
            int[] stat = new int[19];
            for (int i = 0; i < ARRSIZE; i++)
            {
                stat[rArr[i]]++;
            }
            for (int i = 0; i < stat.Length; i++)
            {
                Console.WriteLine(i + " " + stat[i]);
            }
            //44.
            double[] femDubs = { 1.0, 2.5, 4, 3.0, 0.5 };
            double[] tioDubs = new double[10];
            double[] hundraDubs = new double[100];
            FillRandomDoubles(tioDubs, rand);
            FillRandomDoubles(hundraDubs, rand);
            Console.Write("femDubs: ");
            PrintArray(femDubs);
            //44:
            Console.WriteLine("44. " + SumDoubles(femDubs));
            //45:
            Console.WriteLine("45. " + AverageDoubles(femDubs));
            //46:
            Console.Write("46. Kopia : ");
            PrintArray(CopyDoubles(femDubs));
            //47.
            Console.Write("47. Omvänd kopia : ");
            PrintArray(CopyReverseDoubles(femDubs));
            //48.
            Console.Write("48. Insertion sort. Array: ");
            PrintArray(tioDubs);
            PrintArray(InsertionSortDoubles(tioDubs));
            PrintArray(femDubs);
            PrintArray(InsertionSortDoubles(femDubs));
            PrintArray(femDubs);
            //49
            //Star sirius = new Star() { Name = "sirius", Magnitude = -1.46, Distance = };
            //Console.WriteLine(" Name: {0}\n Magnitude: {1}\n Distance: ", sirius.Name, sirius.Magnitude, sirius.Distance);
            Star sirius = new Star("Sirius", -1.46, 8.6) { };
            sirius.Print();
            //52:
            Star[] stars = { new Star("Sun", -26.74, 0.000015823820),
                sirius,
                new Star("Canopus", -0.74, 310),
                new Star("Rigil Kentaurus", -0.27, 4.4),
                new Star("Arcturus", -0.05, 37) };
            foreach (Star s in stars) s.Print();
            
        }
        //44.
        static double SumDoubles(double[] data)
        {
            double sum = 0;
            foreach (double d in data) sum += d;
            return sum;
        }
        //45.
        static double AverageDoubles(double[] data)
        {
            double sum = SumDoubles(data);
            return sum / data.Length;
        }
        //46.
        static double[] CopyDoubles(double[] data)
        {
            double[] arr = new double[data.Length];
            for( int i = 0; i < data.Length; i++ ) arr[i] = data[i];
            return arr;
        }
        //47.
        static double[] CopyReverseDoubles(double[] data)
        {
            int ln = data.Length, i = 0;
            double[] arr = new double[ln];
            while(i < ln)
            {
                arr[i] = data[ln - ++i];
            }
            return arr;
        }
        //48.
        static double[] InsertionSortDoubles(double[] data)
        {
            int ln = data.Length;
            double[] arr = CopyDoubles(data);
            double temp;
            for (int i = 0; i < ln; i++)
            {
                int j = i;
                temp = arr[j];
                while (j > 0 && temp < arr[j - 1]) arr[j] = arr[--j];
                arr[j] = temp;
            };
            return arr;
        }
        static void PrintArray(double[] arr)
        {
            Console.Write("{ ");
            Array.ForEach(arr, e => Console.Write(e + " "));
            Console.WriteLine("}");
        }
        static void FillRandomDoubles(double[] data, Random r)
        {
            for (int i = 0, ln = data.Length; i < ln; i++)
            {
                data[i] = r.NextDouble() * r.Next(1, 10000);
            }
        }


    }
}