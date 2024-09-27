using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб_1__3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Задание #3 про грядки
            int a, b, c, d, rastoyanie;

            a = 5;
            b = 3;
            c = 3;
            
            d = int.Parse(Console.ReadLine());
            rastoyanie = (a + b * 2 + 1 * 2 + 1 * (d - 1) + a) * d;
            Console.WriteLine("Растояние равняется " + rastoyanie);
        }
    }
}
