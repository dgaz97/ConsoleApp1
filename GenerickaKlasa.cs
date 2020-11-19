using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class GenerickaKlasa <IVozilo>
    {
        public IVozilo objekt { get; set; }
        
        public IVozilo dohvatiVozilo()
        {
            return objekt;
        }

    }
}
