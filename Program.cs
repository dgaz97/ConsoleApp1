using System;
using System.Collections.Generic;
using System.Text;

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

            //Test DateTime and TimeSpan
            DateTime date = DateTime.Now;
            Console.WriteLine(date.ToString("dd*MMMM*yy hh.mm.ss.ffffff"));
            DateTime date2 = date.AddMonths(4);
            Console.WriteLine(date2.ToString("dd*MMMM*yy hh.mm.ss.ffffff"));
            TimeSpan timeSpan = date.Subtract(date2);
            Console.WriteLine(timeSpan.TotalDays);
            Console.WriteLine(date.CompareTo(date2));
            Console.WriteLine();

            //Test StringBuilder
            StringBuilder sb = new StringBuilder("pocetak stringa");
            sb.Append($"{osobe[1].ToString()}");
            Console.WriteLine(sb);
            sb.Insert(3, "INSERT");
            Console.WriteLine(sb);
            Console.WriteLine();



        }
    }
}
