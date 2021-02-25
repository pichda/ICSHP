using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraceSPoli
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] pole = new int[10];
            int index = 0;
            char vstup;

            while (true)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("1.Zadaní prvků pole z klávesnice");
                Console.WriteLine("2.Výpis pole na obrazovku");
                Console.WriteLine("3.Utřídění pole vzestupně");
                Console.WriteLine("4.Utřídění pole vzestupně");
                Console.WriteLine("5.Hledání minimálního prvku");
                Console.WriteLine("6.Hledání prvního výskytu zadaného čísla");
                Console.WriteLine("7.Hledání posledního výskytu zadaného čísla");
                Console.WriteLine("8.Konec programu");
                Console.WriteLine("--------------------------------------------");

                try
                {
                    vstup = Convert.ToChar(Console.ReadLine());
                }
                catch (Exception)
                {
                    vstup = '0';
                }

                switch (vstup)
                {
                    case '1':
                        while (index < 10)
                        {
                            Console.WriteLine("Zadej číslo.");
                            pole[index] = Fei.BaseLib.Reading.ReadInt();
                            index++;
                        }
                        break;

                    case '2':
                        for (int i = 0; i < index; i++)
                        {
                            Console.WriteLine(pole[i]);
                        }
                        break;

                    case '3':
                        Array.Sort(pole);
                        break;

                    case '4':
                        Array.Sort(pole);
                        Array.Reverse(pole);
                        break;

                    case '5':
                        Console.WriteLine(pole.Min(prvek => prvek));
                        break;

                    case '6':
                        Console.WriteLine("Zadej hledane cislo:");
                        int hledane;
                        try
                        {
                            hledane = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < index; i++)
                            {
                                if (pole[i] == hledane)
                                {
                                    Console.WriteLine($"První výskyt čísla je:{i}");
                                }
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Špatně zadané číslo");
                        }
                        break;

                    case '7':
                        int pozice = 0;
                        Console.WriteLine("Zadej hledane cislo:");
                        int hledaneCislo;
                        try
                        {
                            hledaneCislo = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < index; i++)
                            {
                                if (pole[i] == hledaneCislo)
                                {
                                    pozice = i;
                                }
                            }
                            Console.WriteLine($"Poslední výskyt čísla je:{pozice}");
                        }
                        catch
                        {
                            Console.WriteLine("Špatně zadané číslo");
                        }
                        break;

                    case '8':
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine($"Špatný vstup:{vstup}");
                        break;
                }
            }
        }
    }
}