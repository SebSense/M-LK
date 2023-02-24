namespace IDP_assg_3
{
    internal class Program
    {
        //D15 - 1. Class representing a chemical element:
        public class ChemElement
        {
            public string name, type;
            public int z;
            public double meltingpoint, boilingpoint;

            //D15 - 3. Create a public method Print within ChemElement
            public void Print()
            {
                Console.WriteLine($"Grundämne: {name}\n  typ: {type}\n  smältpunkt: {meltingpoint} \u00b0K\n  kokpunkt: {boilingpoint} \u00b0K");
            }

            //Constructors:
            public ChemElement(string n, string t, int iZ, double m, double b)
            {
                name = n;
                type = t;
                z = iZ;
                meltingpoint = m;
                boilingpoint = b;
            }
            public ChemElement() { }
        }
        //D15 - 3. ...
        public static void Print(ChemElement element)
        {
            Console.WriteLine($"Grundämne: {element.name}\n  typ: {element.type}\n  smältpunkt: {element.meltingpoint} \u00b0K\n  kokpunkt: {element.boilingpoint} \u00b0K");
        }
        static void Main(string[] args)
        {
            //D15 - 2. Generate three instances of chemical elements:
            ChemElement syre = new ChemElement() { name = "syre", type = "ickemetall", z = 8, meltingpoint = 54.36, boilingpoint = 90.188 };
            ChemElement järn = new ChemElement() { name = "järn", type = "metall", z = 26, meltingpoint = 1811, boilingpoint = 3134 };
            ChemElement guld = new ChemElement() { name = "guld", type = "metall", z = 79, meltingpoint = 1337.33, boilingpoint = 3243 };

            //D15 - 3. Print oxygen, iron and gold
            syre.Print();
            järn.Print();
            Print(guld);

            //D15 - 4. Make an array of 6 elements.
            ChemElement[] grundämnen = new ChemElement[6]
            {
                syre,
                järn,
                guld,
                new ChemElement() { name = "väte", type = "ickemetall", z = 1, meltingpoint = 13.99, boilingpoint = 20.271 },
                new ChemElement("brom", "ickemetall", 35, 265.8, 332.0),
                new ChemElement("kvicksilver", "metall", 80, 234.3210, 629.88)
            };

            //D15 - 5. Make a foreach-loop to print all elements in the array.
            Array.ForEach(grundämnen, e => e.Print());



        }
    }
}