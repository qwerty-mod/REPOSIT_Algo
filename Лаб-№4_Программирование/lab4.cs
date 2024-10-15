using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA4__1
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

            Console.WriteLine("Введите числа");

            while (true)
            {
                int v = int.Parse(Console.ReadLine());
                if (v < 0)
                {
                    break;
                }
                int raz = 1;
                int otv = 0;
                while (v > 0)
                {
                    if ((v % 10) % 2 == 1)
                    {
                        otv += (v % 10) * raz;
                        raz = raz * 10;
                    }
                    v = v / 10;
                }
                if (otv == 0)
                {
                    Console.WriteLine("Нет нечетных цифр");
                }
                else
                {
                    int new_otv = 0;
                    while (otv != 0)
                    {
                        new_otv = new_otv * 10 + otv % 10;
                        otv =otv / 10;
                    }
                    Console.WriteLine(new_otv);
                }




























            }
        }
    }
}
