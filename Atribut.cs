using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    [AttributeUsage(AttributeTargets.Interface)]
    class Atribut:Attribute
    {
        public string tekst { get; set; }
        public Atribut(string t)
        {
            tekst = t;
        }
    }
}
