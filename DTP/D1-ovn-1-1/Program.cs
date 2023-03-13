using System.ComponentModel.Design.Serialization;
using System.Text.RegularExpressions;
using System.Xml;

namespace D1_ovn_1_1
{
    /// <summary>
    ///     
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// 
        /// </summary>
        public static List<string> Nota = new();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Nota.Add("10 kg lök");
            Console.WriteLine("DTP-D1-ovn-1-1 - Affärsnoteprogram\n\nVälkommen till affärsnotprogrammet. Kommandon är 'ny', 'sluta', 'ta bort', 'visa', och 'hjälp'.\n");
            string[] input;
            while(true)
            {
                input = GetString(":").Split(' ');
                if (input[0] == "ny")
                {
                    string ny;
                    if (input.Length > 1)
                    {
                        ny = input[1];
                        for (int i = 2; i < input.Length; i++) ny = String.Concat(ny, " ", input[i]);
                    }
                    else ny = GetString("Lägg till vad? :");
                    Nota.Add(ny);
                    Console.WriteLine(ny + " tillagt!");
                }
                else if (input[0] == "sluta" && input.Length == 1)
                {
                    Console.WriteLine("Adjö!");
                    return;
                }
                else if (input.Length > 1 && "ta bort" == String.Concat(input[0], " ", input[1]))
                {
                    TaBort(Nota, input);
                }
                else if (input[0] == "visa" && input.Length == 1)
                {
                    Visa(Nota);
                }
                else if (input[0] == "hjälp" && input.Length == 1)
                {
                    Help();
                }
            }

        }
        /// <summary>
        /// Gets a string from the user
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns>string literal</returns>
        static string GetString(string prompt)
        {
            Console.Write(prompt + " ");
            return Console.ReadLine();
        }
        /// <summary>
        /// Gets an int from the user.
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns>int literal</returns>
        static int GetInt(string prompt)
        {
            string input;
            Regex regInt = new Regex(@"^-?\d+$");
            Match match;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                match = regInt.Match(input);
            } while(!match.Success);
            return Int32.Parse(input);
        }
        /// <summary>
        /// Placeholder method for unimplemented user commands.
        /// </summary>
        static void NotImplemented()
        {
            Console.WriteLine("Command not implemented yet");
        }
        ///
        static void Help()
        {
            Console.WriteLine("Hjälp:  Affärsnoteprogrammet hanterar en inköpslista. Tillgängliga kommandon:\n" +
                "  ny <sträng> - lägg till ny vara med angiven textsträng\n" +
                "  sluta       - avsluta programmet\n" +
                "  visa        - listar alla varor i listan med indexnummer\n" +
                "  ta bort <n> - tar bort varan med index n\n" +
                "  hjälp       - visa denna hjälp");
        }
        /// <summary>
        /// Prints all elements in list to console with index"
        /// </summary>
        /// <param name="list"></param>
        static void Visa(List<string> list)
        {
            if(list.Count== 0) { Console.WriteLine("Notan är tom."); return; }
            int i = 1;
            Console.WriteLine("Innehåll i notan:");
            foreach (string s in list) { Console.WriteLine("  " + i++ + ": " + s); }
        }
        /// <summary>
        /// Remove one element from a list using non-zero-indexed integer
        /// </summary>
        /// <param name="list"></param>
        /// <param name="input - non-zero indexed integer"></param>
        static void TaBort(List<string> list, string[] input)
        {
            string s;
            if (input.Length > 2) s = input[2];
            else s = GetString("Ange nr i listan att ta bort:");
            if (int.TryParse(s, out int index))
            {
                if (index <= list.Count && index > 0)
                {
                    Console.WriteLine(index + ". " + list[index - 1] + " RADERAD");
                    list.RemoveAt(index - 1);
                }
                else Console.WriteLine("Index " + index + " finns inte i listan");
            }
            else Console.WriteLine(s + " är inte ett giltigt index. Ange endast heltal som motsvarar rader i listan (använd 'visa' för att se listan).");
        }
    }
}