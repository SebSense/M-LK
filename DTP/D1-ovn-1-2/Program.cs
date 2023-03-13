namespace D1_ovn_1_2
{
    internal class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Welcome();
            string input;
            string[] words;
            while(true)
            {
                Console.Write(":");
                input = Console.ReadLine();
                words = input.Split(' ');
                if (input == "hjälp")
                {
                    NotImplemented();
                }
                else if (input == "latin")
                {
                    NotImplemented();
                }
                else if (input == "ny")
                {
                    NotImplemented();
                }
                else if (input == "sluta")
                {
                    Console.WriteLine("Adjö!");
                    return;
                }
                else if (input == "svenska")
                {
                    NotImplemented();
                }
                else if (input == "ta bort")
                {
                    NotImplemented();
                }
                else if (input == "visa")
                {
                    NotImplemented();
                }
            }
        }
        /// <summary>
        /// Print welcome message to console.
        /// </summary>
        static void Welcome()
        {
            NotImplemented();
        }
        static void NotImplemented()
        {
            Console.WriteLine("Command not implemented");
        }
    }
}