using System;
namespace DelegateBasicExample
{
  class Program
  {
    delegate void LogDel(string text);

    static void Main(string[] args)
    {
      Log logClassInstance = new Log();
      //Single delegate cast
      // LogDel log = new LogDel(Logtext);
      // LogDel logToFile = new LogDel(LogTextToFile);
      // LogDel logClassLogtext = new LogDel(logClassInstance.LogtextFromClass);
      // log("Olaaaa");
      // logToFile("Olaaaa");
      // logClassLogtext("Waaaaaaa");


      // Multicas delegate
      // LogDel multiLog = new LogDel(Logtext);
      // multiLog += LogTextToFile;
      // multiLog += logClassInstance.LogtextFromClass;
      // multiLogText(multiLog, "Olaaaa");


      LogDel logDelToFile, logDelToConsole;
      logDelToFile = new LogDel(logClassInstance.LogTextToFile);
      logDelToConsole = new LogDel(logClassInstance.LogtextFromClass);
      LogDel multiLogDel = logDelToFile + logDelToConsole;
      multiLogText(multiLogDel, "Olaaaa");
    }

    static void multiLogText(LogDel logDel, string text)
    {
      logDel(text);
    }
    static void Logtext(string text)
    {
      Console.WriteLine($"{DateTime.Now} :{text}");
    }

    static void LogTextToFile(string text)
    {
      using (StreamWriter sw = new StreamWriter("log.txt", true))
      {
        sw.WriteLine($"{DateTime.Now} :{text}");
      }
    }
  }
  public class Log
  {
    public void LogtextFromClass(string text)
    {
      Console.WriteLine($"{DateTime.Now} :{text}");
    }

    public void LogTextToFile(string text)
    {
      using (StreamWriter sw = new StreamWriter("log.txt", true))
      {
        sw.WriteLine($"{DateTime.Now} :{text}");
      }
    }
  }
}
