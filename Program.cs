using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Osoba> osobe = new List<Osoba>();

            osobe.Add(new Osoba("Ana","Anić",23));
            osobe.Add(new Osoba("Ivo","Ivić",27));
            osobe.Add(new Osoba("Pero","Perić",25));
            osobe.Add(new Osoba("Eva","Ević",22));

            osobe.ForEach(x => Console.WriteLine(x));

            osobe.Sort();

            osobe.ForEach(x => Console.WriteLine(x));

            using (Osoba testOsoba = new Osoba("Ivan","Ivanić", 20))
            {
                Console.WriteLine(testOsoba.ToString());
            }
            Console.Beep();

        }
    }
}
