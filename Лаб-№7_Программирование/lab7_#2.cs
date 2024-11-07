using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7__2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задание 2. дан ступенчатый массив размерностью 4.
            // для каждой строки определить положение элемента
            // значение которого больше чем сумма остальных элементов строки,
            // если такого нет выдать сообщение указав номер строки массива
            
            int[][] mass = new int[4][];

            for (int i = 0; i < 4; i++)
            {
                Console.Write($"Введите количество элементов {i + 1} строки: ");
                int n = int.Parse(Console.ReadLine());
                mass[i] = new int[n];
                Console.WriteLine("Введите элементы строки через Enter");
                for (int j = 0; j < n; j++)
                {
                    mass[i][j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine();

            for (int i = 0; i < 4; i++)
            {
                
                int suma = 0;
                for (int j = 0;j < mass[i].Length; j++)
                {
                    suma += mass[i][j];
                    
                    
                }
                
                int uslovie = 0;
                string posicion = "";
                int EL_proverka = 0;
                for (int j = 0; j < mass[i].Length; j++)
                {
                    int EL = mass[i][j];
                    
                    if (suma - EL < EL)
                    {
                        
                        uslovie = EL;
                        posicion = $"({i},{j})";
                        EL_proverka = EL;
                    }
                    
                }
                if (uslovie != 0)
                {
                    Console.WriteLine($"В строке {i+1} элементом является {EL_proverka}, его позиция в массиве {posicion}");
                }
                else
                {
                    Console.WriteLine($"В стркое {i+1} нет подхоядщих элементов"); 
                }
            }
            Console.WriteLine();
            Console.WriteLine("МАССИВ");
            Console.WriteLine();

            for (int i = 0;i < 4; i++)
            {
                for (int j = 0;j < mass[i].Length; j++)
                {
                    Console.Write(mass[i][j] + " ");
                }
                Console.WriteLine() ;
            }

        }
    }
}
