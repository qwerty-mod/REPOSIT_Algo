using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba5_222
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // дан массив из n положительных целых элементов
            // Задание 2: заменить все четные элементы на 0, нечетные - на 1 


            Console.WriteLine("Введите количество элементов в массиве");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите элементы массива через Enter");

            int[] mass = new int[n]; // создание массива
            for (int i = 0; i < n; i++)
            {
                mass[i] = int.Parse(Console.ReadLine());

                if (mass[i] % 2 == 0)
                {
                    mass[i] = 0;
                }
                else
                {
                    mass[i] = 1;
                }










            }
            
            for (int x = 0; x < n; x++)         //
            {                                   //
                Console.Write(mass[x] + " ");   //
                                                //      Для проверки 
                                                //
            }                                   //
            Console.WriteLine();                //




















        }
    }
}
