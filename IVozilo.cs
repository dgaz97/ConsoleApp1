using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    [Atribut("Ovdje je interface")]
    interface IVozilo
    {

        public Int32 brojKotaca { get; set; }
        public Double duljinaVozila { get; set; }
        public Boolean elektrican { get; set; }

        public String ispisiVozilo();

    }
}
