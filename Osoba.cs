using System;

namespace ConsoleApp1
{
    class Osoba : IComparable, IDisposable
    {
        public Osoba(String ime, String prezime, Int16 dob)
        {
            Ime = ime;
            Prezime = Prezime;
            Dob = dob;
        }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public Int16 Dob { get; set; }

        public int CompareTo(object obj)
        {
            Osoba o = (Osoba)obj;
            //return this.Dob.CompareTo(o.Dob); //manje->vise
            return o.Dob.CompareTo(this.Dob); //vise->manje
        }

        public void Dispose()
        {
            Console.WriteLine($"{Ime} {Prezime} izbrisan");
        }

        public override string ToString()
        {
            return $"{Ime} {Prezime} --- {Dob} godine";
        }
    }
}
