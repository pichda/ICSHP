using System;

namespace Cviceni1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] @pole = { "Josef", "Dan", "Michal" };
            string txt = "Josef Novák\nJindrišská 16\n111 50, Praha 1\n";
            Console.WriteLine(txt);

            for (int i = 0; i < @pole.Length; i++)
            {
                Console.Write($"{pole[i]}\nJindrišská 16\n111 50, Praha 1\n\n");
            }
        }
    }
}