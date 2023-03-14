using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.IO.Enumeration;
using System.Runtime.CompilerServices;

namespace D1_ovn_3
{
    internal class Program
    { 
        class Link
        {
            public string topic, site, title, link;
            public Link(string topic, string site, string title, string link)
            {
                this.topic = topic;
                this.site = site;
                this.title = title;
                this.link = link;
            }   
            public Link(string line)
            {
                string[] lines = line.Split(';');
                this.topic = lines[0];
                this.site = lines[1];
                this.title = lines[2];
                this.link = lines[3];
            }
            public void Print()
            {
                Console.WriteLine(" Topic: " + topic + "\n   Site: " + site + "" +
                    "\n   Title: " + title + "\n   Link: " + link);
            }
        }
        static void Main(string[] args)
        {
            //NYI: En process för att öppna och ändra i filer.

            
            List<Link> weblinks = new();
            //Öppna fil...
            string path = Directory.GetCurrentDirectory();
            string filename = null;
            string input;
            do
            {
                Console.Write(":");
                input = Console.ReadLine();
                string[] words = input.Split(' ');
                int ln = words.Length;
                if(ln == 2 && words[0] == "edit")
                {
                    filename = words[1];
                    Process.Start("notepad", filename);
                }
                else if (ln == 2 && words[0] == "load")
                {
                    filename = words[1];
                    string[] filetext_lines = File.ReadAllLines(path + "\\" + filename);
                    Array.ForEach(filetext_lines, line => weblinks.Add(new Link(line)));
                }
                else if (input == "list")
                {
                    for(int i = 0; i < weblinks.Count; i++)
                    {
                        Console.Write((i + 1) + ".");
                        weblinks[i].Print();
                    }
                }
                else if (input == "open")
                {

                }
                else if (input == "save")
                {
                    StreamWriter writer = new StreamWriter(path + "\\" + filename);
                    for(int i = 0; i < weblinks.Count; i++)
                    {
                        Link link = weblinks[i];
                        if(i != 0) writer.WriteLine();
                        writer.Write(String.Join(';', link.topic, link.site, link.title, link.link));
                    }
                    writer.Close();
                }
                else if (input == "quit")
                {
                    Console.WriteLine("Adjö!");
                    return;
                }
            } while(true);
        }
    }
}