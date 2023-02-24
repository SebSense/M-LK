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
        }
        static void Main(string[] args)
        {
            //D15 - 1. Generate three chemical elements:
            ChemElement syre = new ChemElement() { name = "syre", type = "ickemetall", z = 8, meltingpoint = 54.36, boilingpoint = 90.188 };
            ChemElement järn = new ChemElement() { name = "järn", type = "metall", z = 26, meltingpoint = 1811, boilingpoint = 3134 };
            ChemElement guld = new ChemElement() { name = "guld", type = "metall", z = 79, meltingpoint = 1337.33, boilingpoint = 3243 };
        
        }
    }
}