using System;

namespace Cviceni1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            vypisUkol4();
        }

        public static void vypisUkol1()
        {
            string[] @pole = { "Josef", "Dan", "Michal" };
            string txt = "Josef Novák\nJindrišská 16\n111 50, Praha 1\n";
            Console.WriteLine(txt);

            for (int i = 0; i < @pole.Length; i++)
            {
                Console.Write($"{pole[i]}\nJindrišská 16\n111 50, Praha 1\n\n");
            }
            Console.ReadKey();
        }

        public static void vypisUkol2()
        {
            Console.WriteLine("for abeceda");
            for (int i = 0; i < 26; i++)
            {
                Console.Write(Convert.ToChar(65 + i) + ",");
            }

            int j = 0;
            Console.WriteLine("\n\nwhile abeceda");
            while (true)
            {
                if (j > 25)
                    break;

                Console.Write(Convert.ToChar(65 + j) + ",");
                j++;
            }

            j = 0;
            Console.WriteLine("\n\ndo while abeceda");
            do
            {
                Console.Write(Convert.ToChar(65 + j) + ",");
                j++;
            }
            while (j < 26);

            Console.ReadKey();
        }

        public static void vypisUkol4()
        {
            System.Random rnd = new Random();
            int cislo = rnd.Next(0, 100);

            short pocetPokusu = 0;
            bool konec = false;
            while (!konec)
            {
                {
                    while (pocetPokusu < 10)
                    {
                        Console.WriteLine("Zadej cislo v rozmezi 0-100");
                        int hadaneCislo;
                        bool uspesne = Int32.TryParse(Console.ReadLine(), out hadaneCislo);
                        while (!uspesne)
                        {
                            uspesne = Int32.TryParse(Console.ReadLine(), out hadaneCislo);
                        }
                        pocetPokusu++;

                        if (hadaneCislo > 100 && hadaneCislo < 0)
                        {
                            Console.WriteLine("Číslo nenalezeno");
                        }
                        else
                        {
                            if (hadaneCislo > cislo)
                            {
                                Console.WriteLine("Hádané číslo je vetší než hledané");
                            }
                            else if (hadaneCislo < cislo)
                            {
                                Console.WriteLine("Hádané číslo je menší než hledané");
                            }
                            else
                            {
                                Console.WriteLine($"Uhodl jsi číslo na {pocetPokusu}. pokus. Chceš pokračovat? Stiskni jakoukoliv klávesu pro ano, 'N' pro ne");
                                if (Console.ReadKey(true).Key == ConsoleKey.N)
                                {
                                    konec = true;
                                    break;
                                }
                                else
                                {
                                    pocetPokusu = 0;
                                    cislo = rnd.Next(0, 100);
                                }
                            }
                        }
                        if (pocetPokusu == 10)
                        {
                            Console.WriteLine("Game over");
                            Console.WriteLine($"Hledane čislo bylo {cislo}. Chceš pokračovat? Stiskni jakoukoliv klávesu pro ano, 'N' pro ne");
                            if (Console.ReadKey(true).Key == ConsoleKey.N)
                            {
                                konec = true;
                                break;
                            }
                            else
                            {
                                pocetPokusu = 0;
                                cislo = rnd.Next(0, 100);
                            }
                        }
                    }
                }
            }
        }
    }
}