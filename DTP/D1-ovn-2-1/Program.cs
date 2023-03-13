using System.Diagnostics;

namespace D1_ovn_2_1
{
    internal class Program
    {
        /// <summary>
        /// Räknar antal ord i en fil
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string input = "count", path = Directory.GetCurrentDirectory(), filename = "testfile.txt";
            do
            {
                //Fråga efter kommdo
                if(input == "count")
                {
                    //Ändra till att fråga efter filnamn
                    string text = File.ReadAllText(@"D:\dev\moelk\repos\DTP\D1-ovn-2-1\obj\Debug\net6.0\testfile.txt");
                    Console.WriteLine(text);
                    Console.WriteLine($"Antal rader i {filename}: " + (1 + text.Count(c => c == '\n')));
                    
                    input = "quit";
                    //Anropa metoder för att räkna:
                    //Antal rader
                    //Antal tecken
                    //Antal ord
                    //Printa ut alla tre rad för rad
                }
                //LÄGST PRIO:
                //Kommandon för att navigera filstruktur:
                //else if (dir)
                //else if (cd)
            } while(input != "quit");
            
        }
    }
}