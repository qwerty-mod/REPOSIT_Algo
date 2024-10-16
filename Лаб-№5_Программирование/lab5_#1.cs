using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5__111
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // дан массив из n положительных целых элементов
            //Задание 1: определить кол-во элементов, все цифры которых четные 

            int Itog = 0;

            Console.WriteLine("Введите количество элементов массива");
            int n = int.Parse(Console.ReadLine());

            int[] mass = new int[n]; //создание массива длинной n элемнтов

            Console.WriteLine("Введите элементы массива ");
            for (int i = 0; i < mass.Length; i++)
            {
                mass[i] = int.Parse(Console.ReadLine());


                // ~~~~~~~~~~~~~~~~~~~~~~БЛОК КОДА ГДЕ ПРОВЕРЯЕТСЯ УСЛОВИЕ НА ЧЁТНОСТЬ ВСЕХ ЦИФР В ЧИСЛЕ ~~~~~~~~~~~~~~~~~~~~~~

                int counter = 0; //счётчик для проверки количества подходящих цифр под условия

                int posled_cifra = 0;

                int Kolichestvo_cifr; //количество цифр в элементе массива


                Kolichestvo_cifr = mass[i].ToString().Length;

                while (mass[i] != 0)
                {
                    posled_cifra = mass[i] % 10;
                    mass[i] = mass[i] / 10;
                    if (posled_cifra % 2 == 0)
                    {
                        counter += 1;

                    }


                }
                posled_cifra = 0;      //
                                      //   СБРОС ПЕРЕМЕННЫХ ДЛЯ ПРОВЕРКИ СЛЕДУЮЩИХ ЧИСЕЛ МАССИВА
                                     //




                if (Kolichestvo_cifr == counter)
                {
                    Itog += 1;
                }
                counter = 0; // сброс каунтера

                // ~~~~~~~~~~~~~~~~~~~~~~БЛОК КОДА ГДЕ ПРОВЕРЯЕТСЯ УСЛОВИЕ НА ЧЁТНОСТЬ ВСЕХ ЦИФР В ЧИСЛЕ ~~~~~~~~~~~~~~~~~~~~~~





            }

            Console.WriteLine($"Количество элементов массива со всеми четными цифрами равно: {Itog}");







































        }
    }
}
