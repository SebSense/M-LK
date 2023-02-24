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
            public void Print() {
                Console.WriteLine($"Grundämne: {name}\n  typ: {type}\n  smältpunkt: {meltingpoint}\n  kokpunkt: {boilingpoint}"); }
            
        }
        //D15 - 3. ...
        public static void Print(ChemElement element)
        {
            Console.WriteLine($"Grundämne: {element.name}\n  typ: {element.type}\n  smältpunkt: {element.meltingpoint}\n  kokpunkt: {element.boilingpoint}");
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


        }
    }
}