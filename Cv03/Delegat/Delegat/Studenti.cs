using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegat
{
    public class Studenti
    {
        private Student[] Students { get; set; }
        private int Size { get; set; }

        public Studenti(int arrSize)
        {
            this.Students = new Student[arrSize];
            Size = 0;
        }

        public Student GetStudent(int index)
        {
            if (index > Size)
            {
                throw new ArgumentOutOfRangeException("index", "V poli je mene prvku.");
            }
            else
            {
                return Students[index];
            }
        }
        public void AddStudent()
        {
            Console.WriteLine("Zadej jmeno studenta");
            String jmeno = Console.ReadLine();
            Console.WriteLine("Zadej číslo");
            int cislo = int.MaxValue;
            while (cislo == int.MaxValue)
            {
                try
                {
                    cislo = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Tohle není číslo");
                }
            }
            
            int fakulta = int.MaxValue;
            while (true)
            {
                try
                {
                    Console.WriteLine("Zvol si fakultu.\nFES = 0\nFF=1\nFEI=2\nFCHT=3");
                    fakulta = Int32.Parse(Console.ReadLine());
                    if (fakulta > 3 || fakulta < 0)
                    {
                        Console.WriteLine("Zadej číslo v rozmezí 0-3");
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Tohle není číslo");
                }
            }

            Fakulta fak = Fakulta.FF;
            switch (fakulta)
            {
                case 0: fak = Fakulta.FES;
                    break;
                case 1:
                    fak = Fakulta.FF;
                    break;
                case 2:
                    fak = Fakulta.FEI;
                    break;
                case 3:
                    fak = Fakulta.FCHT;
                    break;
            }
            Student st = new Student(jmeno, cislo, fak);
            Students[Size] = st;
            Size++;
        }

        public void SortByCislo()
        {

            Students = Students.OrderBy(st => st.Cislo).ToArray();
        }
        public void SortByJmeno()
        {
            Students = Students.OrderBy(st => st.Jmeno).ToArray();
        }
        public void SortByFakulta()
        {
            Students = Students.OrderBy(st => st.Fakulta).ToArray();
        }
        public int ArrayLenght()
        {
            return Students.Length;
        }
    }
}
