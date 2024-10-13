using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задание #1: Определить количество локальных минимумов
            int count = 0;

            Console.WriteLine("Введите количество элементов последовательности");
            int i = int.Parse(Console.ReadLine());
            if (i < 3)
            {
                Console.WriteLine("Последовательность слишком короткая");
            }

            Console.WriteLine("Введите элементы последовательности по очереди");
            
            int first = int.Parse(Console.ReadLine()); // первый элемент
            int two = int.Parse(Console.ReadLine()); // второй элемент

            for (int k = 2; k < i; k++)
            {
                int next = int.Parse(Console.ReadLine());
                if (two < first & two < next)
                {
                    count++;
                }
                first = two;
                two = next;           
            }
            Console.WriteLine($"Количетсво локальных минимумов равно: {count}");
            



        }
    }
}
