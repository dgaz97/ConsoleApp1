using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class GenerickaKlasa <T>
        where T:IVozilo
    {
        public T objekt { get; set; }
        
        public T dohvatiVozilo()
        {
            return objekt;
        }

    }
}
