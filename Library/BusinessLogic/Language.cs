using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BusinessLogic
{
    public class Language
    {
        private string _current;
        public string Current { get => _current; }

        public Language(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            string lang = "en";

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].ToLower().StartsWith("--lang="))
                {
                    lang = args[i].Substring(7);
                    break;
                }
            }

            _current = lang;
        }
    }
}
