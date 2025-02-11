﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace крестьянин_и_чёрт
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /////////////////////////////////////////////   КРЕСТЬЯНИН И ЧЁРТ   //////////////////////////////////////////////

            // Формула задачи: 2N - K = 0

            //  N - начальное кол-во монет у крестьянина
            //  K - количество монет, отдаваемых черту после каждого перехода
            //  Z - количество переходов

            //Естественно, что для этой тройки должно выполняться условие, что после Z циклов у крестьянина не должно остаться монет.

            int N = int.Parse(Console.ReadLine()); // количество начальных монет
            
            int count_z = 0; // счётчик ходов

            int counter = 0; //счётчик подходящих строк

            for (int i = 1; i < N+1; i++) // начинаем с i=1, т.к. по истории задачи у крестьянина есть монеты.
            {
                
                for (int k = 1; k < 2*N+1; k++)
                {
                    if (k > i) // это делается для случаев по типу: n=1 and k=1 , циклы бесконечные
                    {
                        int R = (2 * i) - k;  // РЕЗУЛЬТАТ ПЕРЕХОДА ЧЕРЕЗ МОСТ
                        count_z += 1; // ходы через мост


                        if (R == 0) // подходящая строка, когда результат равен 0.
                        { 
                            counter += 1;
                        }
                        else
                        {
                            

                            if (R > 0) // если после перехода на балансе ещё есть деньги
                            {
                                while (R > 0) // крестьянин ходит по мосту до тех пор, пока у него не будет 0 монет на балансе.
                                {
                                    R = (2 * R) - k;
                                    count_z += 1; // ходы через мост
                                }
                                if (R == 0)// подходящая строка, когда результат равен 0.
                                {
                                    
                                    counter += 1;
                                }
                                
                            }
                        }
                        
                    }

                    count_z = 0; // сбрасываем счётчик

                }

            }
            Console.WriteLine("ОТВЕТ: " + counter);


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }
    }
}
