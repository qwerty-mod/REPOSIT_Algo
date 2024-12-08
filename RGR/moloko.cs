using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq; // с помощью этой библиотеки можно вывести минимальное значение одномерного массива методом .Min()
using System.Text;
using System.Threading.Tasks;


namespace moloko
{
    internal class moloko
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine()); // Количество фирм
            double[,] info = new double[n, 8]; // содержит всю информацию которую мы введём

            double[] all_znacheniya = new double[n];  // значения цен за литр молока разных фирм
            double min = 0; // мниимальная цена за литр молока в фирмах которых мы рассматриваем

            for (int i = 0; i < n; i++) // заполняем двумерный массив где кол-во строк это фирмы, а столбцы это информация по условиям задачи 
            {
                string[] input = Console.ReadLine().Split(); // введённую строку на подстроки разбиваем, чтобы потом запарсить в массив info

                for (int j = 0; j < 8; j++)
                {
                    // Указываем, что парсинг идет с использованием InvariantCulture - это нужно для того чтобы можно было ввести числа формата: x.xx 
                    info[i, j] = double.Parse(input[j], CultureInfo.InvariantCulture);
                }
            }
            for (int i = 0; i < n; i++) 
            {

                double money_milk = 0; // цена за литр молока
                for (int j = 0; j < 8; j++)
                {
                    ///// ищем данные по i-той фире чтобы узнать стоимость молока
                    
                    double V1 = info[i, 0] * info[i, 1] * info[i, 2]; // обьём первой упаковки

                    double V2 = info[i, 3] * info[i, 4] * info[i, 5]; // обьём второй упаковки

                    double c1 = info[i, 6]; // цена первой упаковки

                    double c2 = info[i, 7]; // цена второй упаковки

                    double S1 = 2 * (info[i, 0]* info[i, 1] + info[i, 0] * info[i, 2] + info[i, 1] * info[i, 2]); // площадь поверхности первой упаковки

                    double S2 = 2 * (info[i, 3] * info[i, 4] + info[i, 3] * info[i, 5] + info[i, 4] * info[i, 5]); // площадь поверхности второй упаковки

                    money_milk = Math.Round(1000 * ((c2 - c1 * S2 / S1) / (V2 - V1 * S2 / S1)),2); // money_milk - цена за литр молока.
                                                                                                   // методом Math.Round() округляем число до двух знаков после запятой

                    all_znacheniya[i] = money_milk; // заносим в массив где будут все цены на литр молока разных фирм.

                }
                
            }
            min = all_znacheniya.Min(); // минимальное значение которое впринципе существует в массиве который состоит из цен на литр молока разных фирм.
            int index = Array.IndexOf(all_znacheniya, min) + 1; // для случая : "Если имеется несколько фирм с одинаковой минимальной стоимостью собственно молока,
                                                                // то вывести ту из них, номер которой минимален"
                                                                // 
                                                                // А конкретно Array.IndexOf() - индекс первого вхождение минимальной цены за литр молока
            Console.WriteLine();
            Console.WriteLine("Ответ: " + index + " " + min);
            

        }
    }
}
