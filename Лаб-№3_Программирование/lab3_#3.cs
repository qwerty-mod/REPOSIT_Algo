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
            Console.Write("Введите количество элементов в последовательности: ");
            int n = int.Parse(Console.ReadLine());

            int maxSum = int.MinValue;
            int next = 0;

            Console.WriteLine("Введите элементы последовательности через Enter: ");
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num % 2 == 0)
                {
                    next += num;  // Добавляем четное число к текущей сумме
                    if (next > maxSum)
                    {
                        maxSum = next;  // Обновляем максимум, если текущая сумма больше
                    }
                }
                else
                {
                    next = 0;  // Сбрасываем сумму, если число нечетное
                }
            }

            if (maxSum == int.MinValue)
            {
                Console.WriteLine("В последовательности нет четных элементов.");
            }
            else
            {
                Console.WriteLine("Максимальная сумма последовательных четных элементов равна: " + maxSum);
            }

        }
    }
}
