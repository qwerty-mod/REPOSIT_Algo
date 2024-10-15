using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1ррр
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 2.Определить минимальный размер подпослеовательности состоящих из чётных элементов
            Console.WriteLine("Введите количество элементов последовательности: ");
            int n = int.Parse(Console.ReadLine());


            int min = 99999, lenght;



            int next, abs_next;
            Console.WriteLine("Вводите элементы по очереди: ");
            int r1 = int.Parse(Console.ReadLine());


            if (r1 % 2 == 0)
            {
                lenght = 1;
            }
            else
            {
                lenght = 0;
            }


            for (int i = 1; i < n; i++)
            {
                next = int.Parse(Console.ReadLine());
                abs_next = Math.Abs(next);


                if (Math.Abs(next) % 2 == 0)
                {
                    lenght++;
                }
                else
                {
                    if (lenght > 0 && lenght < min)
                    {
                        min = lenght;
                    }
                    lenght = 0;
                }


                r1 = next;
            }
            if (lenght > 0 && lenght < min)
            {
                min = lenght;
            }

            Console.WriteLine($"минимальный размер последовательности из четных {min}");


        }
    }
}
