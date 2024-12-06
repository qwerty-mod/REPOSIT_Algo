using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ргр_1_задание
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //////////////////////////////////////////////////   ОТГАДАЙ ЧИСЛО   ////////////////////////////////////////////////////
            
            // r = ax + b // - формула задачи //
            
            // где r-результат дейсвтий,
            // a-коэффициент перед X,
            // X-задуманное число,
            // b-свободный член
            

            int x, a=1, b=0;
            int N = int.Parse(Console.ReadLine()); // кол-во действий

            for (int i = 0; i < N; i++) // выполняем действия
            {
                
                string znak_chislo = Console.ReadLine(); // формат ввода: *знак* + *пробел* + *число/цифра*

                string[] parts = znak_chislo.Split(' '); // заносим знак и число/цифру в массив
                if (parts[0] == "+") 
                {
                    
                    if (parts[1] == "x") // если не число, а X, то коэфф. перед X увеличивается на 1, т.к. знак "+"
                    {
                        a += 1;
                    }
                    else
                    {
                        b = b + int.Parse(parts[1]); // иначе свободный член увеличивается на введённое число
                    }

                }
                if (parts[0] == "-")
                {
                    if (parts[1] == "x") // если не число, а X, то коэфф. перед X уменьшается на 1, т.к. знак "-"
                    {
                        a -= 1;
                    }
                    else
                    {
                        b = b - int.Parse(parts[1]); // иначе свободный член уменьшается на введённое число
                    }


                }
                if (parts[0] == "*") // умножается и коэфф. перед X , и свободный член.
                {
                    a = a * int.Parse(parts[1]);
                    b = b * int.Parse(parts[1]);
                }
                

            }
            int r = int.Parse(Console.ReadLine());
            x = (r - b) / a; // выражаем X через формулу задачи.
            Console.WriteLine("Вывод: " + x);
            
            
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }

    }

}
    

