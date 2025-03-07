using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        
        Console.WriteLine("Введите числа через пробел:");
        string input = Console.ReadLine();

        // Разделение строки на числа и преобразование в список чисел
        string[] mass = input.Split(' ');
        List<int> numbers = new List<int>();

        foreach (string i in mass)
        {
            if (int.TryParse(i, out int number))
            {
                numbers.Add(number);
            }
        }

        // Используем множество для определения уникальных элементов
        HashSet<int> uniq = new HashSet<int>(numbers);

        // Словарь для хранения частоты появления элементов
        Dictionary<int, int> chastota = new Dictionary<int, int>();

        // Подсчет частоты 
        foreach (int num in uniq)
        {
            int count = 0;
            foreach (int n in numbers)
            {
                if (n == num)
                {
                    count++;
                }
            }
            chastota[num] = count;
        }

        Console.WriteLine("Частота появления элементов:");
        foreach (var kvp in chastota)
        {
            Console.WriteLine($"Элемент {kvp.Key}: {kvp.Value} раз");
        }
    }
}

