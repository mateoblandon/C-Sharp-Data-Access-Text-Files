using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace ConsoleUI
{
  class Program
  {
    public static readonly log4net.ILog log = LogHelper.GetLogger();
    static void Main(string[] args)
    {
      try
      {
        string filePath = @"C:\Users\blandonm\Documents\Cursos\TimCorey\C-Sharp-Data-Access-Text-Files\Demos\Test.txt";
        List<string> lines = File.ReadAllLines(filePath).ToList();
        List<Person> people = new List<Person>();
        
        foreach (var line in lines)
        {
          Person newPerson = new Person();
          string[] entries = line.Split(',');
          newPerson.FirstName = entries[0];
          newPerson.LastName = entries[1];
          newPerson.Url = entries[2];
          people.Add(newPerson);
          Console.WriteLine(line);
        }
        foreach (var person in people)
        {
          Console.WriteLine(string.Format("{0} {1}: {2}", person.FirstName, person.LastName, person.Url));
        }
        people.Add(new Person { FirstName = "Santiago", LastName = "Blandón", Url = "www.santiagoblandon.com" });

        List<string> output = new List<string>();
        foreach (var person in people)
        {
          output.Add(person.FirstName + "," + person.LastName + "," + person.Url);
        }
        File.WriteAllLines(filePath, output);
        Console.WriteLine("Nuevo nombre agredado al archivo");
        Console.ReadLine();
      }
      catch (Exception ex) 
      { 
        log.Debug("Ha ocurrido una excepción:", ex);
        Console.ReadLine();
      }
     }
  }
}
