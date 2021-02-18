using System;

namespace Cviceni1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            vypisUkol2();
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
    }
}