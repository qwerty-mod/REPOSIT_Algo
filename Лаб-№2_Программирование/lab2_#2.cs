using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_2__2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Задание 2: Определить все ли элементы последовательности чётны, на вывод чтобы выходило либо ДА либо НЕТ

            int k = 0;

            Console.WriteLine("Введите количетсов элементов последовательности");
            int n = int.Parse(Console.ReadLine());
            int n1 = n; // n которое нужно для проверки в конце

            Console.WriteLine("Введите элементы последовательности по очереди");

            while (n > 0)
            {
                int curr = int.Parse(Console.ReadLine());
                if (curr%2 == 0)
                {
                    k += 1;
                }
                n--;

            }
            if (n1 == k)
            {
                Console.WriteLine("ДА");
            }
            else
            {
                Console.WriteLine("НЕТ");
            }
            





        }
    }
}
