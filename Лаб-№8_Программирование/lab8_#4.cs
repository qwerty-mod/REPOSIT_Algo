using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8__2
{
    internal class Program
    {
        public static int COUNTER_GLAS(string[] sq) //функция 
        {
            char[] vowels = new char[] { 'а', 'и', 'е', 'ё', 'о', 'у', 'ы', 'э', 'ю', 'я', 'a', 'e', 'i', 'o', 'u', 'y','ь','ъ' }; //Гласные

            string str = String.Join(" ", sq); //Строка
            char[] array = str.ToLower().ToCharArray(); //Разбиваем строку на массив символов

            int vowelsCount = 0; //Количество гласных
            

            foreach (char ch in array)
                foreach (char cha in vowels)
                    if (ch == cha)
                        vowelsCount++;


            return vowelsCount;
        }
        public static int COUNTER_SOGLAS(string[] sq) //функция 
        {
            char[] vowels = new char[] { 'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ',
            'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z'}; //Согласные

            string str = String.Join(" ", sq); //Строка
            char[] array = str.ToLower().ToCharArray(); //Разбиваем строку на массив символов

            
            int consonantsCount = 0; //Количество согласных

            foreach (char ch in array)
                foreach (char cha in vowels)
                    if (ch == cha)
                        consonantsCount++;
            
            

            return consonantsCount;
        }
        static void Main(string[] args)
        {
            //4.дано n строк, выдать только те строки, в которых кол - во гласных букв больше,
            //чем кол-во согласных(ь, ъ считать согласными)


            Console.WriteLine("Введите количество строк");
            int n = int.Parse(Console.ReadLine());
            string[][] Array = new string[n][];
            Console.WriteLine($"Введите строки через Enter");
            for (int i = 0; i < n; i++)
            {
                
                Array[i] = Console.ReadLine().Split();
                
                
            }
            Console.WriteLine();


            for (int i = 0; i < Array.GetLength(0); i++)
            {

                if (COUNTER_GLAS(Array[i]) > COUNTER_SOGLAS(Array[i]))
                {
                    Console.WriteLine(String.Join(" ", Array[i]) + "    " + "согласных: " + COUNTER_SOGLAS(Array[i]) + "   " + "гласных: " + COUNTER_GLAS(Array[i]));
                }
                Console.WriteLine() ;
            }


        }
    }
}
