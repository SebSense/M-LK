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
            string input = "count", path = ".", filename = "testfile.txt";
            do
            {
                //Fråga efter kommdo
                if(input == "count")
                {
                    //Fråga efter filnamn
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