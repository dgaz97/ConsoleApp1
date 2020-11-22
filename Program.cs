﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ConsoleApp1
{
    class Program
    {
        //static Number num = new Number();
        static volatile Int32 num = 0;
        static async Task Main(string[] args)
        {
            List<Osoba> osobe = new List<Osoba>();

            osobe.Add(new Osoba("Ana", "Anić", 23));
            osobe.Add(new Osoba("Ivo", "Ivić", 27));
            //osobe.Add(new Osoba("Pero","Perić",25));

            Type tip = Type.GetType("ConsoleApp1.Osoba");
            Osoba osoba = (Osoba)Activator.CreateInstance(tip, new object[] { (String)"Pero", (String)"Perić", (Int16)25 });//Refleksija
            osobe.Add(osoba);

            osobe.Add(new Osoba("Eva", "Ević", 22));

            //Test IComparable
            osobe.ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            osobe.Sort();

            osobe.ForEach(x => Console.WriteLine(x));

            //Test IDisposable
            using (Osoba testOsoba = new Osoba("Ivan", "Ivanić", 20))
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
            Console.WriteLine();

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

            //Test HTMLEncode

            String s2 = HttpUtility.HtmlEncode($"<a href=\"www.google.com\">test &</>");
            Console.WriteLine(s2);
            Console.WriteLine(HttpUtility.HtmlDecode(s2));
            Console.WriteLine();

            //Test Indexer
            Number n = new Number();
            n[0] = 5;
            n[1] = 6;
            n[2] = 7;
            n[3] = 8;
            n[4] = 9;
            Console.WriteLine(n[3]);

            //Test Lambda
            testLambda(7);
            Action a = () => Console.WriteLine("Drugi test lambda uspjesan");
            a.Invoke();


            //Test file
            DirectoryInfo di = Directory.CreateDirectory(@"./file/");
            Stream f = new FileStream(@"./file/testfile.txt", FileMode.OpenOrCreate | FileMode.Append);
            StreamWriter sw = new StreamWriter(f);
            sw.WriteLine("Linija");
            sw.Close();
            f.Close();
            f = new FileStream(@"./file/testfile.txt", FileMode.Open, FileAccess.Read);
            using (StreamReader sr = new StreamReader(f))
            {
                while (!sr.EndOfStream)
                {
                    Console.WriteLine(sr.ReadLine());
                }
            }
            f.Close();
            Console.WriteLine();

            Stream f2 = new FileStream(@"./file/objects.txt", FileMode.OpenOrCreate);
            //BinaryWriter bw = new BinaryWriter(f2);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(f2, osobe);
            f2.Close();
            Console.WriteLine("DESERIALIZED");
            List<Osoba> osobe2;
            f2 = new FileStream(@"./file/objects.txt", FileMode.Open, FileAccess.Read);
            osobe2 = (List<Osoba>)binaryFormatter.Deserialize(f2);
            osobe2.ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine();

            //Test File Info
            FileInfo fi = new FileInfo(@"./file/objects.txt");
            Console.WriteLine(fi.FullName);
            Console.WriteLine(fi.CreationTime);
            Console.WriteLine(fi.LastAccessTime);
            Console.WriteLine();
            f2.Close();
            fi.CopyTo(@"./file/objects_copy.txt", true);
            File.Delete(fi.FullName);

            //Test Generic
            //Number n = new Number(); //već postoji
            Console.WriteLine(n.genericnaMetoda(16M));
            Console.WriteLine(n.genericnaMetoda("asdf"));
            Console.WriteLine(n.genericnaMetoda(0x56a));
            GenerickaKlasa<IVozilo> gk = new GenerickaKlasa<IVozilo>();
            gk.objekt = new Motor();
            gk.objekt.brojKotaca = 2;
            gk.objekt.duljinaVozila = 1.75;
            gk.objekt.elektrican = true;
            Console.WriteLine(gk.dohvatiVozilo().ispisiVozilo());

            //Test Atributa
            Atribut[] atrArray = (Atribut[])gk.dohvatiVozilo().GetType().GetInterfaces()[0].GetCustomAttributes(typeof(Atribut), true);
            Console.WriteLine(atrArray.Length);
            foreach (var i in atrArray)
            {
                Console.WriteLine(i.tekst);
            }
            osoba.zastarjelaMetoda();
            Console.WriteLine();

            //Test Delegate
            n.d = (object x) => $"{x} dobiven iz main metode";
            Console.WriteLine(n.test(16));

            Console.WriteLine(n.deleTest(6.8D, x =>
            {
                return $"{Math.Pow((double)x, 3)}";
            }));

            //test dictionary
            SortedDictionary<string, Osoba> ht = new SortedDictionary<string, Osoba>();
            osobe.ForEach(x =>
            {
                ht.Add(x.Prezime, x);
            });
            foreach (KeyValuePair<string, Osoba> kvp in ht)
            {
                Console.WriteLine($"{kvp.Key} --- {kvp.Value.ToString()}");
            }


            List<Task<int>> threads = new List<Task<int>>();
            for (int i = 1; i <= 10; i++)
            {
                threads.Add(dretva1(i));
            }
            await Task.WhenAll(threads);
            Console.WriteLine($"Zbroj na kraju: {num}");

        }

        private static void testLambda(int x) => Console.WriteLine($"Lambda test uspješan {x}");

        private static async Task<int> dretva1(int brojDretve)
        {
            await Task.Delay(100);
            int c = 0;
            for (int i = 1; i <= 500000; i++)
            {
                c += i;
                Interlocked.Add(ref num, i);
                if (i % 10000 == 0) Console.WriteLine($"dretva {brojDretve} zbrojila do {i}");
            }
            Console.WriteLine($"Dretva {brojDretve} završila sa {c}");
            return c;

        }

    }
}
