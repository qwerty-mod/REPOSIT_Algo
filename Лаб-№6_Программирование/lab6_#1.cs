using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA6__111
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задание 1. дан массив m*n отсортировать столбцы массива по возрастанию их сумм
            Console.Write("Введите количество строк: ");
            int str = int.Parse(Console.ReadLine());

            Console.Write("Введите количество столбцов: ");
            int stolb = int.Parse(Console.ReadLine());

            
            int[,] mass = new int[str, stolb];
            Console.WriteLine("Введите элементы каждой строки через пробел:");
            for (int i = 0; i < str; i++)
            {
                string[] rowValues = Console.ReadLine().Split(' ');
                for (int j = 0; j < str; j++)
                    mass[i, j] = int.Parse(rowValues[j]);
            }

            // Сортировка строк по их суммам
            for (int i = 0; i < str - 1; i++)
            {
                for (int j = i + 1; j < str; j++)
                {
                    int sumI = 0, sumJ = 0;
                    for (int k = 0; k < stolb; k++)
                    {
                        sumI += mass[i, k];
                        sumJ += mass[j, k];
                    }
                    if (sumI > sumJ)
                    {
                        // Поменяем местами строки i и j.
                        for (int k = 0; k < stolb; k++)
                        {
                            int temp = mass[i, k];
                            mass[i, k] = mass[j, k];
                            mass[j, k] = temp;
                        }
                    }
                }
            }

            // Отображаем отсортированный массив
            Console.WriteLine("Массив, отсортированный по суммам строк:");
            for (int i = 0; i < str; i++)
            {
                for (int j = 0; j < stolb; j++)
                    Console.Write(mass[i, j] + " ");
                Console.WriteLine();
            }
        }














    }
    
}
