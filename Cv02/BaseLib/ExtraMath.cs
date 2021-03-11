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

        /// <summary>
        /// Vraci nahodne double cislo v min - max rozmezi
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public double rndDouble(int min, int max)
        {
            return rnd.NextDouble() * (max - min) + min;
        }
        /// <summary>
        /// Vraci reseni kvadraticke rovnice. Pokud má reseni: True, pokud ne: False
        /// Vraci parametry x1, x2. Pokud nemá reseni, vrací tyto parametry s maximalni double hodnotou.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <returns></returns>
        public bool HasQaudraticSolution(int a, int b, int c, out double x1, out double x2)
        {

            double d;

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
                x1 = double.MaxValue;
                x2 = double.MaxValue;
                return false;
            }
                
        }
    }
}
