using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SchuhS_Balkezesek
{
    class Program
    {
        static List<Balkezes> BalkezesList;
        static Dictionary<string, double> NevMagassagCmDict;
        static int Evszam;
        static void Main(string[] args)
        {
            Feladat2Beolvasas(); Console.WriteLine("\n---------------------------------\n");
            Feladat3SorokSzama(); Console.WriteLine("\n---------------------------------\n");
            Feladat4Magassag(); Console.WriteLine("\n---------------------------------\n");
            Feladat5Beker(); Console.WriteLine("\n---------------------------------\n");
            Console.ReadKey();
        }

        private static void Feladat5Beker()
        {
            Console.WriteLine("5.Feladat: évszám bekérése 1990 és 1999 között");
            Evszam = 0;
            do
            {

                Console.Write("\n\tKérem adjon meg egy évszámot 1990 és 1999 között: ");
                Evszam = int.Parse(Console.ReadLine());
                if (Evszam < 1990 || 1999 < Evszam)
                {
                    Console.WriteLine("\tHibás adat, próbálja újra");

                }
                else
                {
                    Console.WriteLine("\tSikeres évszám megadás");
                    Console.WriteLine("\n---------------------------------\n");
                    Feladat6();
                }


            } while (Evszam < 1990 || 1999 < Evszam);            
        }

        private static void Feladat6()
        {
            Console.WriteLine("6.Feladat: a megadott évben ({0}) a pályára lépett versenyzők átlag súlya", Evszam);
            string VizsgaltEv = Evszam.ToString();
            double OsszesSuly = 0;
            double AtlagSuly = 0;
            int db = 0;
            foreach (var b in BalkezesList)
            {
                if(b.ElsoPalyaralepes.Contains(VizsgaltEv))
                {
                    db++;
                    OsszesSuly += b.Suly;
                    AtlagSuly = OsszesSuly / db;
                }
            }
            Console.WriteLine("\tEbben az évben ({0}) indulók átlag testsúlya: {1:0.00}",Evszam, AtlagSuly);

        }

        private static void Feladat4Magassag()
        {
            Console.WriteLine("\n4.Feladat: azok versenyzők magassága cm-ben akik 1999 októberében léptek utoljára pályára");
            NevMagassagCmDict = new Dictionary<string, double>();
            double MagassagCm = 0;
            int db = 0;
            foreach (var b in BalkezesList)
            {
                if(b.UtolsoPalyaralepes.Contains("1999-10"))
                {
                    MagassagCm = (double)b.Magassag * 2.54;
                    if(!NevMagassagCmDict.ContainsKey(b.Nev))
                    {
                        NevMagassagCmDict.Add(b.Nev, MagassagCm);
                    }
                    Console.WriteLine("\t{0:00} Név: {1, -20} -> magasság: {2:0.00} cm", db++,b.Nev,MagassagCm);
                }
            }
            /*Console.WriteLine("\n---------------------------------\n");
            int db1 = 0;
            foreach (var n in NevMagassagCmDict)
            {
                Console.WriteLine("\t{0:00} Név:{1, -20} -> magasság: {2:0.00} cm", db1++, n.Key,n.Value);
            }*/
            
        }

        private static void Feladat3SorokSzama()
        {
            Console.WriteLine("\n3.Feladat: határozza meg a beolvasott sorok számát");
            Console.WriteLine("\tBeolvastt sorok száma: {0}", BalkezesList.Count);
        }

        private static void Feladat2Beolvasas()
        {
            Console.WriteLine("\n2.Feladat: Balkezes Lista beolvasása");
            BalkezesList = new List<Balkezes>();
            var sr = new StreamReader(@"balkezesek.csv", Encoding.UTF8);
            int db = 0;
            while(!sr.EndOfStream)
            {
                db++;
                BalkezesList.Add(new Balkezes(sr.ReadLine()));
            }
            sr.Close();
            if(db>0)
            {
                Console.WriteLine("\tSikeres beolvasás, beolvasott sorok száma: {0}", db);
            }
            else
            {
                Console.WriteLine("\tSikertelen beolvasás");
            }
        }
    }
}
