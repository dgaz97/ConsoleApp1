﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Kamion:IVozilo
    {
        public int brojKotaca { get; set; }
        public double duljinaVozila { get; set; }
        public bool elektrican { get; set; }

        public string ispisiVozilo()
        {
            String x = elektrican ? "te je električan" : "te nije električan";
            return $"Vozilo Kamion ima {brojKotaca} kotača, dugačko je {duljinaVozila} metara {x}";
        }
    }
}
