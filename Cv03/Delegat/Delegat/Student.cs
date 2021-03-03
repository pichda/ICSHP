using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegat
{
    public class Student
    {
        public string Jmeno { get; set; }
        public int Cislo { get; set; }
        public Fakulta Fakulta { get; set; }

        public static int CompareByJmeno(Student st1, Student st2)
        {
            return String.Compare(st1.Jmeno, st2.Jmeno);
        }
        public static int CompareByCislo(Student st1, Student st2)
        {
            return st1.Cislo.CompareTo(st2.Cislo);
        }
        public static int CompareByFakutla(Student st1, Student st2)
        {
            return st1.Fakulta.CompareTo(st2.Fakulta);
        }

        public Student(string jmeno, int cislo, Fakulta fakulta)
        {
            this.Jmeno = jmeno;
            this.Cislo = cislo;
            this.Fakulta = fakulta;
        }

        public override string ToString()
        {
            return $"Jmeno:{Jmeno}, cislo:{Cislo}, fakulta:{Fakulta}";
        }
    }
}