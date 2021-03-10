using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLib
{
    class MathConvertor
    {
        /// <summary>
        /// prevod decimalni do binarni
        /// </summary>
        /// <returns></returns>
        public string ToBinaryFromDecimal()
        {
            Console.Write("Zadej decimalni cislo:");
            int input = int.Parse(Console.ReadLine());
            return Convert.ToString(input, 2);
        }
        /// <summary>
        /// prevod binarni do decimalni
        /// </summary>
        /// <returns></returns>
        public int ToDecimalFromBinary()
        {
            Console.Write("Zadej binarni cislo:");
            string input = Console.ReadLine();
            return Convert.ToInt32(input, 2);
        }

        public virtual int value(char r)
        {
            if (r == 'I')
                return 1;
            if (r == 'V')
                return 5;
            if (r == 'X')
                return 10;
            if (r == 'L')
                return 50;
            if (r == 'C')
                return 100;
            if (r == 'D')
                return 500;
            if (r == 'M')
                return 1000;
            return -1;
        }
        /// <summary>
        /// Prevadi rimskou do decimalni hodnoty. MAX(0-3999)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public virtual int RomanToDecimal(string str)
        {
            int res = 0;

            for (int i = 0; i < str.Length; i++)
            {
                int s1 = value(str[i]);

                if (i + 1 < str.Length)
                {
                    int s2 = value(str[i + 1]);

                    if (s1 >= s2)
                    {
                        res = res + s1;
                    }
                    else
                    {
                        res = res + s2 - s1;
                        i++; 
                    }
                }
                else
                {
                    res = res + s1;
                    i++;
                }
            }

            return res;
        }

        /// <summary>
        /// Prevadi decimalni do rimske hodnoty. MAX(0-3999)
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string ToRoman(int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new ArgumentOutOfRangeException("something bad happened");
        }
    }
}
