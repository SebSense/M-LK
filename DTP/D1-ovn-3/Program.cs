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
            //TBD: Add one string containing the unformatted line from the savefile
            //TBD: Make the class abstract - change to private variables with properties.
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
                Console.WriteLine("\tTopic: " + topic + "\n\tSite: " + site + "" +
                    "\n\tTitle: " + title + "\n\tLink: " + link);
            }
        }
        static void Main(string[] args)
        {  
            List<Link> weblinks = new();
            string path = Directory.GetCurrentDirectory();
            string filename;
            string input;
            //REPL:
            do
            {
                Console.Write("\n:");
                input = Console.ReadLine();
                string[] words = input.Split(' ');
                int ln = words.Length;
                if(ln == 2 && words[0] == "edit")
                {
                    filename = words[1];
                    Process.Start("notepad", filename);
                }
                else if (ln == 2 && words[0] == "load")
                {   //CLEANUP:
                    filename = words[1];
                    string[] filetext_lines = File.ReadAllLines(path + "\\" + filename);
                    foreach(string line in filetext_lines)
                    {
                        if (weblinks.All(l => String.Join(';',l.topic,l.site,l.title,l.link) != line)) weblinks.Add(new Link(line));
                    }
                    //Array.ForEach(filetext_lines, line => weblinks.Add(new Link(line)));
                }
                else if (input == "list")
                {
                    //CLEANUP: Turn into methodsa
                    for(int i = 0; i < weblinks.Count; i++)
                    {
                        Console.Write((i + 1) + ".");
                        weblinks[i].Print();
                    }
                }
                else if (ln == 3 && words[0] == "list")
                {
                    if (words[1] == "topic")
                    {
                        foreach (Link link in weblinks)
                        {
                            if (link.topic == words[2])
                            {
                                Console.Write((weblinks.IndexOf(link) + 1) + ". ");
                                link.Print();
                            }
                        }
                    }
                    else if (words[1] == "site")
                    {
                        foreach (Link link in weblinks)
                        {
                            if (link.site == words[2])
                            {
                                Console.Write((weblinks.IndexOf(link) + 1) + ". ");
                                link.Print();
                            }
                        }
                    }
                }
                else if (words[0] == "open")
                {   //CLEANUP:
                    using (Process browser = new Process()) 
                    {
                        browser.StartInfo.UseShellExecute = true;
                        if (ln == 2)
                        {
                            if (int.TryParse(words[1], out int index))
                            {
                                browser.StartInfo.FileName = weblinks[index - 1].link;
                                browser.Start();
                            }
                        }
                        else if (ln == 3 && words[1] == "topic")
                        {
                            foreach (Link link in weblinks)
                            {
                                if (link.topic != words[2]) continue;
                                browser.StartInfo.FileName = link.link;
                                browser.Start();
                            }
                        } 
                    }
                }
                else if (ln < 3 && words[0] == "save")
                {   // TBD: Spara inte dubletter.
                    // CLEANUP:
                    if (ln == 2) filename = words[1];
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