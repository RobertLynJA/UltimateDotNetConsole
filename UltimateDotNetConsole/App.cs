using Library.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateDotNetConsole
{
    public class App
    {
        private readonly IMessages _messages;

        public App(IMessages messages)
        {
            _messages = messages;
        }

        public void Run(string[] args)
        {
            Console.WriteLine(_messages.Greeting);
        }
    }
}
