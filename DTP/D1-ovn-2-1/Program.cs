using System.Diagnostics;
using System.Text.RegularExpressions;

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
            string input, path = Directory.GetCurrentDirectory(), filename;
            Console.WriteLine("Text counter: Welcome to the text counter program.\nThis program counts lines, characters and words in .txt-files.");
            do
            {
                Console.WriteLine("Commands are 'count' and 'quit'");
                Console.Write("Command: ");
                input = Console.ReadLine();
                if (input == "count")
                {
                    Console.Write("Input filenamne: ");
                    filename = Console.ReadLine();
                    string fullPath = path + "\\" + filename;
                    if (!File.Exists(fullPath)) { Console.WriteLine("Cannot find file"); continue; }
                    string text = File.ReadAllText(fullPath);
                    //Console.WriteLine(text);
                    Console.WriteLine($"Antal rader i {filename}: " + (1 + text.Count(c => c == '\n')));
                    Console.WriteLine($"Antal tecken i {filename}: " + text.Count(c => !Array.Exists("\n\t\0 ".ToCharArray(), elem => elem == c)));
                    Regex regWord = new Regex(@"(^[A-Za-z0-9])|(?<=[ \n\t])[A-Za-z0-9]");
                    Console.WriteLine($"Antal ord i {filename}: " + regWord.Matches(text).Count);
                }
                //LÄGST PRIO:
                //Kommandon för att navigera filstruktur:
                //else if (dir)
                //else if (cd)
            } while(input != "quit");
            
        }
    }
}