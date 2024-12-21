using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3__3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество чисел > 1:");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите числа:");
            int elements = int.Parse(Console.ReadLine());
            int currNum = elements;

            int maxEvenSum = int.MinValue; // Максимальная сумма четной подпоследовательности
            int currSum = 0;        // Текущая сумма четной подпоследовательности

            if (currNum % 2 == 0)   // Проверяем первое число
            {
                currSum += currNum;
            }

            while (n > 1)
            {
                elements = currNum;
                currNum = int.Parse(Console.ReadLine());

                if (currNum % 2 == 0) // Если число четное
                {
                    currSum += currNum;
                }
                else // Если число нечетное
                {
                    if ((currSum > maxEvenSum) && (elements % 2 == 0))
                    {
                        maxEvenSum = currSum;
                    }
                    currSum = 0;
                }
                n--;
            }

            // Проверка последней подпоследовательности
            if ((currSum > maxEvenSum) && (currNum % 2 == 0))
            {
                maxEvenSum = currSum;
            }

            // Вывод результата
            if (maxEvenSum == int.MinValue)
            {
                Console.WriteLine("Четных элементов нет");
            }
            else
            {
                Console.WriteLine("Максимальная сумма подпоследовательности четных элементов: " + maxEvenSum);
            }


        }
    }
}

