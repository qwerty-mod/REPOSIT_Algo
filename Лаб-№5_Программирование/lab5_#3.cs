using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5_333
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // дан массив из n положительных целых элементов
            // Задание 3: сформировать выходной массив, в который необходимо сначала положить все четные элементы, а потом нечетные

            Console.WriteLine("Введите количество элементов массива");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите элементы массива");
            int[] mass = new int[n];
            int counter = 0;
            for (int y = 0; y < n; y++)
            {
                mass[y] = int.Parse(Console.ReadLine());

            }
            // Формирование выходного массива
            for (int i = 0; i < n; i++)
            {
                if (mass[i]%2 == 0)
                {
                    mass[counter] = mass[i];
                    counter++;
                }

            }
            for (int x = 0; x < n; x++)
            {
                if (mass[x]%2 != 0)
                {
                    mass[counter] = mass[x];
                    counter++;


                }


            }
            

            for (int q = 0; q < n; q++)
            {
                Console.Write(mass[q] + " ");

            }
            Console.WriteLine();











        }    
    }
}
