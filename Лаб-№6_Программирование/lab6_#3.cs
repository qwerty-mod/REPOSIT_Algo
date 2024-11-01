using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6__3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Введите количество строк: ");
            int str = int.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов: ");
            int stolb = int.Parse(Console.ReadLine());

            
            int[,] mass = new int[str, stolb];
            for (int i = 0; i < str; i++)
            {
                Console.Write($"Введите элементы {i + 1} строки через пробел: ");
                string[] rowValues = Console.ReadLine().Split();
                for (int j = 0; j < stolb; j++)
                    mass[i, j] = int.Parse(rowValues[j]);
            }

            // 1) Найдём и выведем элемент который является максимальным в строке и минимальным в столбце   
            for (int i = 0; i < str; i++)
            {
                int maxInSTR = mass[i, 0];
                int maxInSTOLB = 0;

                for (int j = 1; j < stolb; j++)
                {
                    if (mass[i, j] > maxInSTR)
                    {
                        maxInSTR = mass[i, j];
                        maxInSTOLB = j;
                    }
                }

                // Проверка, является ли этот максимум минимумом в своем столбце.
                bool MININ_stolb = true;
                for (int k = 0; k < str; k++)
                {
                    if (mass[k, maxInSTOLB] < maxInSTR)
                    {
                        MININ_stolb = false;
                        break;
                    }
                }

                // Вывод, если условия выполнены
                if (MININ_stolb)
                {
                    Console.WriteLine($"Максимальный в строке и минимальнцый в столбце = {maxInSTR} на позиции [{i}, {maxInSTOLB}]");
                }
            }

            // 2) Найдём и выведем элемент который является минимальным в строке и максимальным в столбце
            for (int i = 0; i < str; i++)
            {
                int minInRow = mass[i, 0];
                int minColIndex = 0;

                for (int j = 1; j < stolb; j++)
                {
                    if (mass[i, j] < minInRow)
                    {
                        minInRow = mass[i, j];
                        minColIndex = j;
                    }
                }

                // Проверка, является ли этот минимум максимальным в своем столбце.
                bool isMaxInCol = true;
                for (int k = 0; k < str; k++)
                {
                    if (mass[k, minColIndex] > minInRow)
                    {
                        isMaxInCol = false;
                        break;
                    }
                }

                // Вывод, если условия выполнены
                if (isMaxInCol)
                {
                    Console.WriteLine($"Минимальный в строке и максимальный в столбце = {minInRow} на позиции [{i}, {minColIndex}]");
                }


            }





        }
    }   
    
}
