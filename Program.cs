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
            //osobe.Add(new Osoba("Pero","Perić",25));

            Type tip = Type.GetType("ConsoleApp1.Osoba");
            Osoba osoba = (Osoba)Activator.CreateInstance(tip, new object[] { (String)"Pero", (String)"Perić", (Int16)25 });//Refleksija
            osobe.Add(osoba);

            osobe.Add(new Osoba("Eva","Ević",22));

            //Test IComparable
            osobe.ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            osobe.Sort();

            osobe.ForEach(x => Console.WriteLine(x));

            //Test IDisposable
            using (Osoba testOsoba = new Osoba("Ivan","Ivanić", 20))
            {
                Console.WriteLine(testOsoba.ToString());
            }
            Console.Beep();
            Console.WriteLine();


            //Test exception
            try
            {
                osobe.Add(new Osoba("Test", "Testić", -35));
            }
            catch (LosaDobException ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                osobe.Add(new Osoba("Test", "Testić", 145));
            }
            catch (LosaDobException ex)
            {
                Console.WriteLine(ex.Message);
            }
            osobe.ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            //Test ConsoleKeyInfo
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            cki = System.Console.ReadKey();
            Console.WriteLine(cki.Key.ToString());
            Console.WriteLine(cki.Modifiers);
            Console.WriteLine(cki.KeyChar.ToString());
            if (cki.Key == ConsoleKey.D)
            {
                Console.WriteLine("Pritisnuto D");
            }

            //Console.WriteLine(Environment.GetCommandLineArgs()[0]);



        }
    }
}
