using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace lab9__2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //На вход дается набор строк, признак окончания ввода строк - пустая строка.
            //Задание 2. Определить максимальную длину подстроки в каждой строе, 
            //состоящей из сочетания abc, при этом необязательно присутствуют все три символа.
            //Например, подстрока abcabcabc и abca тоже считаются.

            Console.WriteLine("Введите строки (пустая строка для завершения):");
            int maxLength = 0;

            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) break;

                int currentLength = 0;
                char expectedChar = 'a'; // Начинаем с символа 'a'

                foreach (char c in line)
                {
                    if (c == expectedChar)
                    {
                        currentLength++;

                        // Переходим к следующему символу
                        if (expectedChar == 'a') expectedChar = 'b';
                        else if (expectedChar == 'b') expectedChar = 'c';
                        else if (expectedChar == 'c') expectedChar = 'a'; // Цикл повторяется
                    }
                    else if (c == 'a') // Если порядок нарушен, но видим 'a', начинаем заново
                    {
                        currentLength = 1;
                        expectedChar = 'b';
                    }
                    else
                    {
                        currentLength = 0;
                        expectedChar = 'a';
                    }

                    // Обновляем максимальную длину
                    if (currentLength > maxLength)
                        maxLength = currentLength;
                }
            }

            Console.WriteLine($"Максимальная длина подстроки: {maxLength}");






















        }
    }
}
