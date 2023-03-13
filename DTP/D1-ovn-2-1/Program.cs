using System.Diagnostics;
using System.Text.RegularExpressions;

namespace wc
{
    internal class Program
    {
        /// <summary>
        /// wc.exe - wordcount. Returns number of lines, words and characters in a .txt file
        /// arguments:
        /// /s - stat. Returns statistics for number of times characters a-z (not case-sensitve) occurs in the file.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int ln = args.Length;
            if (ln < 1 || ln > 2) { Console.WriteLine("Syntax Error. WordCount usage: wc <filename.txt> <argument> "); return; }
            if (args[0] == "/h" || args[0] == "help")
            {
                Console.WriteLine("wc - WordCount. Returns number of lines, words and charactersa in a .txt file\n" +
                    "\nSyntax: 'wc file.txt argument'" +
                    "\nArguments:" +
                    "\nwc <filename> stat\twc <filename> /s\tstat - displays statistics for how many times each letter a-z occurs in file (non-case sensitive)" +
                    "\nwc help\t\t\twc /h\t\t\thelp - displays this help");
                return;
            }
            {
                string fullPath = Directory.GetCurrentDirectory() + "\\" + args[0];
                if (!File.Exists(fullPath)) { Console.WriteLine("Cannot find file"); return; }
                string text = File.ReadAllText(fullPath);
                //Console.WriteLine(text);
                Console.WriteLine($"Antal rader i {args[0]}: " + (1 + text.Count(c => c == '\n')));
                Console.WriteLine($"Antal tecken i {args[0]}: " + text.Count(c => !Array.Exists("\n\t\0 ".ToCharArray(), elem => elem == c)));
                Regex regWord = new Regex(@"(^[A-Za-z0-9])|(?<=[ \n\t])[A-Za-z0-9]");
                Console.WriteLine($"Antal ord i {args[0]}: " + regWord.Matches(text).Count);

                if (ln == 2 && (args[1] == "/s" || args[1] == "stat"))
                {
                    text = text.ToLower();
                    string chars = "abcdefghijklmnopqrstuvwxyz";
                    foreach (char c in chars) Console.WriteLine(c + ": " + text.Count(e => e == c));
                }
            }
        }
    }
}
//21-ovn-2-3: Sekvensiering
/*
 * 1. Ändra filnamn till wc.exe
 * 2. Ändra input till hårdkodade argument {filnamn.txt} för count därefter {filnamn.txt /s} (för stat)
 * 3. Mappa if-else kedjan till de hårdkodade argumenten och provkör programmet.
 * 3.5 Lägg till /h help argument för att ge info
 * 4. Ändra de hårkodade argumenten till args[], lägg .exe i %PATH och provkör från cmd
 */