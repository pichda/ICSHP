using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fei
{
    namespace BaseLib
    {
        public class Reading
        {
            /// <summary>
            /// Cte uzivatelsky vstup a vrati double. Pokud je vstup spatny, vrati 0.0
            /// </summary>
            /// <returns></returns>
            static public double ReadDouble(string msg)
            {
                double vstup;
                try
                {
                    vstup = Convert.ToDouble(Console.ReadLine());
                    return vstup;
                }
                catch
                {
                    return 0.0;
                }
            }

            /// <summary>
            /// Cte uzivatelsky vstup a vrati int. Pokud je vstup spatny, vrati 0
            /// </summary>
            /// <returns></returns>
            static public int ReadInt()
            {
                int vstup;
                try
                {
                    vstup = Convert.ToInt32(Console.ReadLine());
                    return vstup;
                }
                catch
                {
                    return 0;
                }
            }

            /// <summary>
            /// Precte prvni znak od uzivatele a vrati char.
            /// </summary>
            /// <returns></returns>
            static public char ReadChar()
            {
                Console.WriteLine("Zadej znak");
                char c = Convert.ToChar(Console.Read());
                return c;
            }

            /// <summary>
            /// Precte cely radek a vrati String.
            /// </summary>
            /// <returns></returns>
            static public string ReadString()
            {
                String input = Console.ReadLine();
                return input;
            }
        }
    }
}