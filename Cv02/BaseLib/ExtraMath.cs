using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLib
{
    class ExtraMath
    {
        public Random rnd;

        public ExtraMath()
        {
            rnd = new Random();
        }

        public double rndDouble(int min, int max)
        {
            return rnd.NextDouble() * (max - min) + min;
        }

        public bool HasQaudraticSolution(int a, int b, int c)
        {

            double d, x1, x2;

            d = b * b - 4 * a * c;
            if (d == 0)
            {
                Console.WriteLine("Oba dva koreny jsou si rovny.");
                x1 = -b / (2.0 * a);
                x2 = x1;
                Console.WriteLine("Prvni koren= {0}", x1);
                Console.WriteLine("Druhy koren= {0}", x2);
                return true;
            }
            else if (d > 0)
            {
                Console.WriteLine("Oba dva koreny jsou realne");

                x1 = (-b + Math.Sqrt(d)) / (2 * a);
                x2 = (-b - Math.Sqrt(d)) / (2 * a);

                Console.WriteLine("Prvni koren= {0}", x1);
                Console.WriteLine("Druhy koren= {0}", x2);
                return true;
            }
            else
            {
                Console.WriteLine("Zadne reseni");
                return false;
            }
                
        }
    }
}
