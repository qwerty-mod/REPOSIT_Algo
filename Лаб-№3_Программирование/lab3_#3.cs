using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA3__3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxsum = -99999, summa = 0;



            Console.WriteLine("Введите количество элементов последовательности");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Вводите элементы последовательности по очереди: ");
            int r1 = int.Parse(Console.ReadLine());


            if (Math.Abs(r1) % 2 == 0)
            {
                summa = summa + r1;
            }
            else
            {
                summa = 0;
            }


            for (int i = 1; i < n; i++)
            {
                int next = int.Parse(Console.ReadLine());
                if (Math.Abs(next) % 2 == 0)
                {
                    summa = summa + next;
                }
                else
                {
                    if (summa > 0 & maxsum < summa)
                    {
                        maxsum = summa;
                    }
                    summa = 0;

                }

                next = r1;
            }
            if (summa > 0 & maxsum < summa)
            {
                maxsum = summa;
            }
            Console.WriteLine("Максимальная сумма последовательности чётных элементов равна: " + maxsum);




















        }
    }
}
