using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8__1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Задание 1. Дана строка, необходимо отформатировать ее таким образом,
            //чтобы между словами было ровно по одному пробелу

            Console.WriteLine("Введите строку:");
            string str = Console.ReadLine();

            string result = "";
            bool flag = false;

            foreach (char c in str)
            {
                if (c != ' ') // Если это не пробел, добавьте символ к результату
                {
                    result += c;
                    flag = true;
                }
                else if (flag) // Если после слова стоял пробел, добавить один пробел
                {
                    result += ' ';
                    flag = false;
                }
            }

            Console.WriteLine("Форматированная строка:");
            Console.WriteLine(result);










        }
    }
}
