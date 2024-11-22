using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace laba9__1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // На вход дается набор строк, признак окончания ввода строк - пустая строка. 
            // Задание 1.Определить количество строк, в которых присутствуют сочетания a*b, где * -любой символ.

            int itogoviy_count = 0;
            int counter = 0;
            int i = 20;
            Console.WriteLine("Введите строки");
            while (i > 0)
            {
                string s = Console.ReadLine();
                if (s == "")
                {
                    break;
                }
                
                
                // ПРОВЕРКА НА A*B
                else
                {
                    char[] mass = new char[s.Length];
                    for (int j = 0; j < s.Length; j++)
                    {
                        mass[j] = s[j] ;
                        
                    }
                    for (int j = 0; j < s.Length - 2; j++)
                    {
                        if (mass[j] == 'a' || mass[j + 2] == 'b')
                        {
                            counter += 1;
                        }
                    }
                }
                if (counter != 0)
                {
                    itogoviy_count += 1;
                }
                counter = 0;
            }
            Console.WriteLine("Количество строк подходящих под условие: " + itogoviy_count);

        }
    }
}
