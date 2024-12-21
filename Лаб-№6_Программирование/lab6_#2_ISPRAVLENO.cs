using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество строк: ");
        int str = int.Parse(Console.ReadLine());
        Console.Write("Введите количество столбцов: ");
        int stolb = int.Parse(Console.ReadLine());

        // Создание массива и заполнение его
        int[,] mass = new int[str, stolb];
        for (int i = 0; i < str; i++)
        {
            Console.Write($"Введите элементы для строки {i + 1} через пробел: ");
            var rowValues = Console.ReadLine().Split(' ');
            for (int j = 0; j < stolb; j++)
            {
                mass[i, j] = int.Parse(rowValues[j]);
            }
        }

        // Сравниваем строки
        for (int i = 0; i < str; i++)
        {
            for (int j = i + 1; j < str; j++) // Исправлено: цикл должен проверять строки, а не столбцы
            {
                // Создание временных массивов для подсчёта элементов
                int[] count1 = new int[101]; // Ограничение диапазона элементов [0, 100]
                int[] count2 = new int[101];

                int sum1 = 0, sum2 = 0;

                // Подсчет элементов и суммы в первой строке
                for (int k = 0; k < stolb; k++)
                {
                    count1[mass[i, k]]++;
                    sum1 += mass[i, k];
                }

                // Подсчет элементов и суммы во второй строке
                for (int k = 0; k < stolb; k++)
                {
                    count2[mass[j, k]]++;
                    sum2 += mass[j, k];
                }

                // Проверка совпадают ли значения и суммы
                bool identical = true;
                if (sum1 != sum2)
                {
                    identical = false;
                }
                else
                {
                    for (int k = 0; k < count1.Length; k++)
                    {
                        if (count1[k] != count2[k])
                        {
                            identical = false;
                            break;
                        }
                    }
                }
                Console.WriteLine();
                // Если они идентичны, вывести индексы
                if (identical)
                {
                    Console.WriteLine($"Идентичные строки найдены в: {i + 1} и {j + 1}");
                }
            }
        }
    }
}

