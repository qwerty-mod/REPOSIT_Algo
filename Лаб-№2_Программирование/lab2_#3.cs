using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Задание 3: Необходимо определить два максимума

            Console.WriteLine("Введите количество элементов: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите элементы последовательности");
            int max1 = int.Parse(Console.ReadLine());
            int max2 = int.Parse(Console.ReadLine());

            if (max1 < max2)
            {
                int p = max1; // если срабатывает проверка, то меняем местами max1 и max2
                max1 = max2;
                max2 = p;
            }

            for (int i = 2; i < n ; i++)
            {
                int el = int.Parse(Console.ReadLine());
                if (el > max1)
                {
                    max2 = max1;
                    max1 = el;
                }
                else if (el > max2)
                {
                    max2 = el;
                }
            }
            Console.WriteLine($"Максимумы: {max1}, {max2};");



        }   
    }
}
