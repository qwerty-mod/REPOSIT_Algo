using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab_6_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задание 2. Определить номера пар строк, состоящих из одинаковых элементов (1 1 2 и 2 1 1 считается)

            Console.Write("Введите количество строк: ");
            int str = int.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов: ");
            int stolb = int.Parse(Console.ReadLine());

            // Создание массива и заполнение его
            string[,] mass = new string[str, stolb];
            for (int i = 0; i < str; i++)
            {
                Console.Write($"Введите элементы для строки {i} через пробел: ");
                var rowValues = Console.ReadLine().Split(' ');
                for (int j = 0; j < stolb; j++)
                {
                    mass[i, j] = rowValues[j];
                }
            }

            // Сравниваем строки
            for (int i = 0; i < str; i++)
            {
                for (int j = i + 1; j < stolb; j++)
                {
                    // Создание временного массива для подсчёта элементов
                    int[] count1 = new int[999]; // Предполагая, что элементы представляют собой однозначные числа
                    int[] count2 = new int[999];

                    // Подсчет элементов в первой строке

                    for (int k = 0; k < stolb; k++)
                    {
                        count1[int.Parse(mass[i, k])]++;
                    }

                    // Подсчет элементов во второй строке

                    for (int k = 0; k < stolb; k++)
                    {
                        count2[int.Parse(mass[j, k])]++;
                    }

                    // Проверка совпадают ли значения
                    bool indificator = true;
                    for (int k = 0; k < 999; k++)
                    {
                        if (count1[k] != count2[k])
                        {
                            indificator = false;
                            break;
                        }
                    }

                    // Если они идентичны, выведим индексы
                    if (indificator)
                    {
                        Console.WriteLine($"Идентичные строки найдены в: {i} и {j}");
                    }
                }
                
            }
        }








    }














    



      



    
    
}
