using System;

class Program
{
    static void Main()
    {
        Console.Write("Кол-во элементов: ");
        int n = int.Parse(Console.ReadLine());

        // "Указатель" на массив 
        int[] El = new int[n];

        
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введите элемент {i + 1}: ");
            El[i] = int.Parse(Console.ReadLine());
        }

        
        int countDivBy2 = 0;
        for (int i = 0; i < n; i++)
        {
            if (El[i] % 2 == 0)
                countDivBy2++;
        }

        Console.WriteLine($"Количество элементов, кратных двум: {countDivBy2}");
    }
}

