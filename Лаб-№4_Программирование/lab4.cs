using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7__2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //на вход подаётся последовательность положительных целых элементов,
            //признак окончания последовательности - неположительный элемент,
            //каждый элемент последовательности преобразовать следующим образом:
            //
            //изменить порядок представления числа на обратный, удалив все четные цифры;
            //в том случае, если в числе нет нечётных цифр, выдать сообщение "нет нечётных цифр"

            Console.WriteLine("Введите числа:");

            while (true)
            {
                int num = int.Parse(Console.ReadLine());

                // Остановите цикл, если число равно нулю или отрицательному значению.
                if (num <= 0)
                {
                    break;
                }

                int reversed = 0;
                bool flag = false;

                // Перевернуть число и удалить четные цифры
                while (num > 0)
                {
                    int chislo = num % 10;

                    if (chislo % 2 == 1) // Если цифра нечетная
                    {
                        reversed = reversed * 10 + chislo; // Добавляем его к перевернутому числу
                        flag = true;
                    }

                    num /= 10; // Удалить последнюю цифру из числа
                }

                if (flag)
                {
                    Console.WriteLine(reversed); // Вывести перевернутое число
                }
                else
                {
                    Console.WriteLine("Нет нечетных цифр"); // Если нет нечетных цифр
                }
            }
        }   
    }
}
