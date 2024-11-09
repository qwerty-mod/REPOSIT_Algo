using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8__2
{
    internal class Program
    {
        public static string ReverseString(string s) //функция для создания полидрома
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
        static void Main(string[] args)
        {
            // 2.необходимо в строке, состоящей из слов, между которыми по 1 пробелу,
            // выдать все слова - перевертыши(палиндромы)

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
            string[] polidrom = result.Split(' ');

            Console.WriteLine();

            Console.WriteLine("Форматированная строка:");
            Console.WriteLine();
            for (int i = 0; i < polidrom.Length; i++)
            {
                Console.Write(ReverseString(polidrom[i]) + " ");
            }
        }
    }
}
