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
            // 3. определить, является ли строка палиндромом

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
            string[] stroka_no_massiv = result.Split(' ');
            

            Console.WriteLine();
            
           
            
            for (int i = 0; i < polidrom.Length; i++)
            {
                polidrom[i] = ReverseString(polidrom[i]);
            }
            Console.WriteLine("ИСХОДНАЯ СТРОКА:");
            Console.WriteLine();
            for (int x = 0; x < polidrom.Length; x++)
            {
                Console.Write(polidrom[x] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("ПЕРЕВЁРНУТАЯ СТРОКА:");
            Console.WriteLine();
            for (int x = 0; x < stroka_no_massiv.Length; x++)
            {
                Console.Write(stroka_no_massiv[x] + " ");
            }
            Console.WriteLine() ;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            flag = false;
            
            
                for (int j = 0; j < polidrom.Length; j++)
                {
                    if (polidrom[j] == stroka_no_massiv[j])
                    {
                        flag = true;

                    }
                    else
                    {
                        
                        flag = false;
                        break;
                    }
                    
                }
            
            


            if (flag)
            {
                Console.WriteLine("ДА,СТРОКА ЯВЛЯЕТСЯ ПОЛИДРОМОМ");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("НЕТ,СТРОКА НЕ ЯВЛЯЕТСЯ ПОЛИДРОМОМ");
                Console.WriteLine();
            }

        }
    }
}
