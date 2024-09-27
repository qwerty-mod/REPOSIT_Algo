using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб_1_прог
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Задача #1
            // Условие:  поменять значения переменых используя только эти 2 переменные
            
            int a, b;
            Console.WriteLine("Введите значение для переменной (a)");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение для переменной (b)"); 
            b = int.Parse(Console.ReadLine());

            a = a + b;
            b = a - b;
            a = a - b;
            
            Console.WriteLine("Теперь переменная (a) равна " + a);
            Console.WriteLine("А переменная (b) равна " + b);

            







        }
    }
}
