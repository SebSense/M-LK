using System.Diagnostics;

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
        }
        static void Main(string[] args)
        {
            //NYI: En process för att öppna och ändra i filer.
            Process notepad = new Process();
            notepad.StartInfo.FileName = "notepad";
            
            //Öppna fil...
            string[] text_lines = File.ReadAllLines("weblinks.lis");
            List<Link> weblinks = new();
            Array.ForEach(text_lines, line => weblinks.Add(new Link(line)));
            //Testprint
            foreach(Link link in weblinks)
            {
                Console.WriteLine("Topic: " + link.topic + "\nSite: " + link.site + "" +
                    "\nTitle: " + link.title + "\nLink: " + link.link);
            }
            //TBD: Main while-loop
            do
            {
                //nested if, else... commands:
                //
            }while(true);
        }
    }
}