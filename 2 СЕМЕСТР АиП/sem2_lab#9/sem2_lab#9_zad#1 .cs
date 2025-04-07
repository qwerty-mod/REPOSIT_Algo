using System;

class Program
{
    static void Main()
    {
        
        Console.Write("Введите первое число: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите второе число: ");
        double b = Convert.ToDouble(Console.ReadLine());

        // Лямбда-выражения для операций
        Func<double, double, double> plus = (x, y) => x + y;
        Func<double, double, double> minus = (x, y) => x - y;
        Func<double, double, double> umnozh = (x, y) => x * y;
        Func<double, double, double> delit = (x, y) => y != 0 ? x / y : 0; // Деление на 0 — вернёт 0

        
        for (int i = 0; i < 1; i++)
        {
            Console.WriteLine($"Сложение: {plus(a, b)}");
            Console.WriteLine($"Вычитание: {minus(a, b)}");
            Console.WriteLine($"Умножение: {umnozh(a, b)}");

            if (b == 0)
                Console.WriteLine("Деление: Ошибка (деление на 0)");
            else
                Console.WriteLine($"Деление: {delit(a, b)}");
        }
    }
}

