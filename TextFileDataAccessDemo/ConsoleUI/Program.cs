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
        string filePath = @"C:\Documents\Cursos\TimCorey\C-Sharp-Data-Access-Text-Files\Demos\Test.txt";
        List<string> lines = File.ReadAllLines(filePath).ToList();
        foreach (string line in lines)
        {
          Console.WriteLine(line);
        }
        Console.ReadLine();
      }
      catch (Exception ex) 
      { 
        log.Debug("Ha ocurrido una excepción:", ex
          );
        Console.ReadLine();
      }
     }
  }
}
