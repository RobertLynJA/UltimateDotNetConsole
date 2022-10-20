using Library.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateDotNetConsole;

public class App
{
    private readonly IMessages _messages;

    public App(IMessages messages)
    {
        _messages = messages;
    }

    public void Run(string[] args)
    {
        string lang = "en";

        for (int i = 0; i < args.Length; i++)
        {
            if (args[i].ToLower().StartsWith("--lang="))
            {
                lang = args[i].Substring(7);
                break;
            }
        }

        string message = _messages.Greeting(lang);
        Console.WriteLine(message);
    }
}
