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
            // Условие: надо из 2 переменных вывести наибольшую нельзя использовать max , if , знаки сравнения

            Console.WriteLine("Введите первое число");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Ввдите второе число");
            int b = int.Parse(Console.ReadLine());

            a = (a + b + Math.Abs(a - b)) / 2;
            Console.WriteLine("Наибольшее число этой пары = " + a);



        }
    }
}
