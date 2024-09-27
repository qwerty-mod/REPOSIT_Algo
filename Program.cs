using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задача #2
            

            Console.WriteLine("Введите количество элементов последовательности");
            
            int count1 = int.Parse(Console.ReadLine());
            int count2 = count1; 
            int k = 0;

            while (count1 > 0)
            {
                
                int sss = int.Parse(Console.ReadLine());
                count1 -= 1;

                if ((sss % 2) == 0)
                {
                    k += 1;
                    
                }
            }
            if (k == count2)
            {
                Console.WriteLine("Да, все элементы последовательности чётны");
            }
            else 
            {
                Console.WriteLine("Нет, не все элементы последовательности чётны");
            }
        }
    }
}
