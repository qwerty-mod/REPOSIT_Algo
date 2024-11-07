using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7__2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задание 1: Определить максимальный размер подпоследовательности состоящий из одинаковых элементов
            int max = -999;
            int lenght = 1;

            Console.WriteLine("Введите количество элементов последовательности");
            int n = int.Parse(Console.ReadLine());
            if (n < 2)
            {
                Console.WriteLine("Последовательность слишком короткая, введите больше элементов");

            }

            int r1 = int.Parse(Console.ReadLine());
            for (int i = 0; i < n - 1; i++)
            {
                int next = int.Parse(Console.ReadLine());
                if (next == r1)
                {
                    lenght++;
                }
                else
                {
                    lenght = 1;
                }
                r1 = next;
                if (lenght > max)
                {
                    max = lenght;
                }


            }
            Console.WriteLine($"Максимальная длина подпоследовательности : {max}");

        }
    }
}
