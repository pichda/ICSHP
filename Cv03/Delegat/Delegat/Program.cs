using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegat
{
    class Program
    {
        static void Main(string[] args)
        {
            Studenti studenti = new Studenti(3);
            char vstup;
            while (true)
            {

                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("1.Načtení studentů z klávesnice");
                Console.WriteLine("2.Výpis studentů na obrazovku");
                Console.WriteLine("3.Seřazení studentů podle čísla");
                Console.WriteLine("4.Seřazení studentů podle jména");
                Console.WriteLine("5.Seřazení studentů podle fakulty");
                Console.WriteLine("0.Konec programu");
                Console.WriteLine("--------------------------------------------");


                try
                {
                    vstup = Convert.ToChar(Console.ReadLine());
                }
                catch (Exception)
                {
                    vstup = 'a';
                }

                switch (vstup)
                {
                    case '1':
                        for (int i = 0; i < studenti.ArrayLenght(); i++)
                        {
                            Console.WriteLine("--------------------------------------------");
                            studenti.AddStudent();
                            Console.WriteLine("--------------------------------------------");
                        }
                        break;
                    case '2':
                        for (int i = 0; i < studenti.ArrayLenght(); i++)
                        {
                            Console.WriteLine(studenti.GetStudent(i));
                        }
                        break;
                    case '3':
                        studenti.SortByCislo();
                        break;
                    case '4':
                        studenti.SortByJmeno();
                        break;
                    case '5':
                        studenti.SortByFakulta();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
