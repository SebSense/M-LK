using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;
using Perfolizer.Mathematics.SignificanceTesting;

[MemoryDiagnoser]
public class Program
{
    ///Förbereder BenchmarkDotNet:
    private class AllowNonOptimized : ManualConfig
    {
        public AllowNonOptimized()
        {
            // AddValidator<AllowNonOptimized>();
            Add(JitOptimizationsValidator.DontFailOnError); // ALLOW NON-OPTIMIZED DLLS

            Add(DefaultConfig.Instance.GetLoggers().ToArray()); // manual config has no loggers by default
            Add(DefaultConfig.Instance.GetExporters().ToArray()); // manual config has no exporters by default
            Add(DefaultConfig.Instance.GetColumnProviders().ToArray()); // manual config has no columns by default
        }

        private void AddValidator<T>()
        {
            throw new NotImplementedException();
        }
    }
    ///classen Dataobjekt och Subthing utgör "dummy"-objekt för att fylla ett array och lista för testning.
    class Subthing
    {
        public string Name { get; set; } = "Namehere";
        public string Description { get; set; } = "A descriptive variable";
        public string Type { get; set; }
        public string TypeDescription { get; set; } = string.Empty;
        public string DescriptionDescription { get; set; }
    }
    class Dataobject
    {
        public int[] ints = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 1, 2, 3, 4, 5, 6, 7, 8, 89, 10, 1, 2, 3, 4, 52, 6, 5, 4, 3, 2, 1, 2, 3, 4, 5, 6, 5, 4, 3, 2, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 91, 19, 93, 94, 95, 96, 97, 98, 99, 100 };
        public string Name { get; set; } = "default";
        public string Description { get; set; } = "a longer string to take up a bit more memory.";
        public string Type { get; set; }
        public string Description2 { get; set; } = "another longish string. How many instances of this object do I want to create for the test do you think?";
        public string Type2 { get; set; }
        public string Type3 { get; set; }
        public Subthing[] Subthings = { new Subthing(), new Subthing(), new Subthing(), new Subthing() };
    }
    //Initiera variabler som skall testas. Ett array och en lista för varje datatyp.
    const int n = 100000;
    int[] int_array = new int[n];
    List<int> int_list = new();
    bool[] bool_array = new bool[n];
    List<bool> bool_list = new();
    string[] string_array = new string[n];
    List<string> string_list = new();
    //Olika långa strängar för att testa iterering genom bokstäverna
    string wordstring = "LoremIpsum",
        shortstring = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
        longstring = "";
    Dataobject[] object_array = new Dataobject[n];
    List<Dataobject> object_list = new();
    //GlobalSetup körs för att förbereda inför tester. For-loopen körs 100 000 ggr och befolkar alla arrayer och listor med 100 000 element.
    //För int array och list fylls varje element med slumptal mellan 1 och 10000. Algoritmer som static metoder kan då testas genom MetodAttTesta(int_array[i], int_array[i+1]) t ex.
    [GlobalSetup]
    public void GlobalSetup()
    {
        Random ran = new();
        for (int i = 0; i < n; i++)
        {
            int r = ran.Next(1, 1000);
            int_array[i] = r;
            int_list.Add(r);
            bool_array[i] = true;
            bool_list.Add(true);
            string_array[i] = wordstring;
            string_list.Add(wordstring);
            longstring += r.ToString();
            object_array[i] = new Dataobject();
            object_list.Add(new Dataobject());
        }
    }
    ///Test av loopars hastighet:
    [Benchmark]
    public void Bool_array_for_loop()
    {
        for (int i = 0, len = bool_array.Length; i < len; i++) ;
    }
    [Benchmark]
    public void Bool_array_for_loop_novar()
    {
        for (int i = 0; i < bool_array.Length; i++) ;
    }
    [Benchmark]
    public void Bool_array_foreach_loop()
    {
        foreach (bool b in bool_array) ;
    }
    [Benchmark]
    public void Bool_array_ForEach_method()
    {
        Array.ForEach(bool_array, b => { });
    }
    [Benchmark]
    public void Bool_list_for_loop()
    {
        for (int i = 0, len = bool_list.Count; i < len; i++) ;
    }
    [Benchmark]
    public void Bool_list_for_loop_novar()
    {
        for (int i = 0; i < bool_list.Count; i++) ;
    }
    [Benchmark]
    public void Bool_list_foreach_loop()
    {
        foreach (bool b in bool_list) ;
    }
    [Benchmark]
    public void Bool_list_ForEach_method()
    {
        bool_list.ForEach(b => { });
    }
    [Benchmark]
    public void Int_array_for_loop()
    {
        for (int i = 0, len = int_array.Length; i < len; i++) ;
    }
    [Benchmark]
    public void Int_array_for_loop_novar()
    {
        for (int i = 0; i < int_array.Length; i++) ;
    }
    [Benchmark]
    public void Int_array_foreach_loop()
    {
        foreach (int b in int_array) ;
    }
    [Benchmark]
    public void Int_array_ForEach_method()
    {
        Array.ForEach(int_array, b => { });
    }
    [Benchmark]
    public void Int_list_for_loop()
    {
        for (int i = 0, len = int_list.Count; i < len; i++) ;
    }
    [Benchmark]
    public void Int_list_for_loop_novar()
    {
        for (int i = 0; i < int_list.Count; i++) ;
    }
    [Benchmark]
    public void Int_list_foreach_loop()
    {
        foreach (int b in int_list) ;
    }
    [Benchmark]
    public void Int_list_ForEach_method()
    {
        int_list.ForEach(b => { });
    }
    [Benchmark]
    public void String_array_for_loop()
    {
        for (int i = 0, len = string_array.Length; i < len; i++) ;
    }
    [Benchmark]
    public void String_array_for_loop_novar()
    {
        for (int i = 0; i < string_array.Length; i++) ;
    }
    [Benchmark]
    public void String_array_foreach_loop()
    {
        foreach (string b in string_array) ;
    }
    [Benchmark]
    public void String_array_ForEach_method()
    {
        Array.ForEach(string_array, b => { });
    }
    [Benchmark]
    public void String_list_for_loop()
    {
        for (int i = 0, len = string_list.Count; i < len; i++) ;
    }
    [Benchmark]
    public void String_list_for_loop_novar()
    {
        for (int i = 0; i < string_list.Count; i++) ;
    }
    [Benchmark]
    public void String_list_foreach_loop()
    {
        foreach (string b in string_list) ;
    }
    [Benchmark]
    public void String_list_ForEach_method()
    {
        string_list.ForEach(b => { });
    }
    [Benchmark]
    public void Object_array_for_loop()
    {
        for (int i = 0, len = object_array.Length; i < len; i++) ;
    }
    [Benchmark]
    public void Object_array_for_loop_novar()
    {
        for (int i = 0; i < object_array.Length; i++) ;
    }
    [Benchmark]
    public void Object_array_foreach_loop()
    {
        foreach (object b in object_array) ;
    }
    [Benchmark]
    public void Object_array_ForEach_method()
    {
        Array.ForEach(object_array, b => { });
    }
    [Benchmark]
    public void Object_list_for_loop()
    {
        for (int i = 0, len = object_list.Count; i < len; i++) ;
    }
    [Benchmark]
    public void Object_list_for_loop_novar()
    {
        for (int i = 0; i < object_list.Count; i++) ;
    }
    [Benchmark]
    public void Object_list_foreach_loop()
    {
        foreach (object b in object_list) ;
    }
    [Benchmark]
    public void Object_list_ForEach_method()
    {
        object_list.ForEach(b => { });
    }
    [Benchmark]
    public void Wordstring_for_loop()
    {
        for (int i = 0, len = wordstring.Length; i < len; i++) ;
    }
    [Benchmark]
    public void Wordstring_for_loop_novar()
    {
        for (int i = 0; i < wordstring.Length; i++) ;
    }
    [Benchmark]
    public void Wordstring_foreach_loop()
    {
        foreach (char c in wordstring) ;
    }
    [Benchmark]
    public void Shortstring_for_loop()
    {
        for (int i = 0, len = shortstring.Length; i < len; i++) ;
    }
    [Benchmark]
    public void Shortstring_for_loop_novar()
    {
        for (int i = 0; i < shortstring.Length; i++) ;
    }
    [Benchmark]
    public void Shortstring_foreach_loop()
    {
        foreach (char c in shortstring) ;
    }
    [Benchmark]
    public void Longstring_for_loop()
    {
        for (int i = 0, len = longstring.Length; i < len; i++) ;
    }
    [Benchmark]
    public void Longstring_for_loop_novar()
    {
        for (int i = 0; i < longstring.Length; i++) ;
    }
    [Benchmark]
    public void Longstring_foreach_loop()
    {
        foreach (char c in longstring) ;
    }


    ///Test av olika metoder för uppgifterna från tentan. Definieras som static-metoder efter main.
    
    
    //[Benchmark]
    //public void BM_SumEvens_Iterative()
    //{
    //    int len = int_array.Length;

    //    for (int i = 0; i < len - 1; i++)
    //    {
    //        SumEvens_Iterative(int_array[i], int_array[i + 1]);
    //    }
    //}    
    //[Benchmark]
    //public void BM_SumEvens_Iterative_optimized()
    //{
    //    int len = int_array.Length;

    //    for (int i = 0; i < len - 1; i++)
    //    {
    //        SumEvens_Iterative_optimized(int_array[i], int_array[i + 1]);
    //    }
    //}
    //[Benchmark]
    //public void BM_SumEvens_Recursive()
    //{
    //    int len = int_array.Length;

    //    for (int i = 0; i < len - 1; i++)
    //    {
    //        SumEvens_Recursive(int_array[i], int_array[i + 1]);
    //    }
    //}
    //[Benchmark]
    //public void BM_SumEvens_Recursive_no_accumulator()
    //{
    //    int len = int_array.Length;

    //    for (int i = 0; i < len - 1; i++)
    //    {
    //        SumEvens_Recursive_no_accumulator(int_array[i], int_array[i + 1]);
    //    }
    //}
    //[Benchmark]
    //public void BM_SumInverses_Iterative()
    //{
    //    int len = listValues.Count;

    //    for (int i = 0; i < len - 1; i++)
    //    {
    //        SumInverses_Iterative(values[i], values[i + 1]);
    //    }
    //}
    //[Benchmark]
    //public void BM_SumInverses_Recursive()
    //{
    //    int len = listValues.Count;

    //    for (int i = 0; i < len - 1; i++)
    //    {
    //        SumInverses_Recursive(values[i], values[i + 1]);
    //    }
    //}
    static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<Program>(config: new AllowNonOptimized());
    }
}
