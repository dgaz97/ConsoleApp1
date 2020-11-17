using System;

namespace ConsoleApp1
{
    class Osoba : IComparable, IDisposable
    {
        public String Ime { get; set; }
        public String Prezime { get; set; }

        private Int16 _dob;
        public Int16 Dob { 
            get 
            {
                return _dob;
            } 
            set
            {
                if (value < 0)
                {
                    throw new LosaDobException("Dob ne može biti manja od 0");
                }
                else if (value > 130)
                {
                    throw new LosaDobException("Dob ne može biti veća od 130 (još?)");
                }
                else _dob = value;
            }
        }
        public Osoba(String ime, String prezime, Int16 dob)
        {
            Ime = ime;
            Prezime = prezime;
            Dob = dob;
        }

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
