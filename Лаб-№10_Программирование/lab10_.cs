using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10__1
{
    internal class lab10_
    {
        class My_first_class
        {
    /*Создается класс, где две переменных целого типа.Конструкторы следующие: 
    1. Конструктор без аргументов.
    2. Конструктор, который принимает 1 аргумент для инициализации.
    3. Конструктор, который принимает 2 аргумента для инициализации.
    Если конструктор без аргументов - проинициализировать нулями.
    Если 1 аргумент, то второе значение проинициализировать нулем.
    Записать 4 метода:
    1. Суммирование двух переменных класса
    2. Произведение двух переменных класса
    3. Разность двух переменных класса
    4. Деление первого аргумента на второй.Проверить деление на ноль
    Без свойств
    3 конструктора в зависимости от принимаемых значений. Один объект на основе первого конструктора, второй на основе второго и третий на основе третьего*/

            //РЕШЕНИЕ

            int a, b; // Две переменные целого типа

            // Конструктор 1. без аргументов, инициализация нулями
            public My_first_class()
            {
                a = 0;
                b = 0;
            }

            // Конструктор 2. с одним аргументом, второй аргумент - ноль
            public My_first_class(int x)
            {
                a = x;
                b = 0;
            }

            // Конструктор 3. с двумя аргументами
            public My_first_class(int x, int y)
            {
                a = x;
                b = y;
            }

            // Метод 1. суммирования двух переменных
            public int Sum()
            {
                return a + b;
            }

            // Метод 2. произведения двух переменных
            public int proizvedenie()
            {
                return a * b;
            }

            // Метод 3. разности двух переменных
            public int minus()
            {
                return a - b;
            }

            // Метод 4. деления первого аргумента на второй (с проверкой деления на ноль)
            public string delenie()
            {
                if (b == 0) return "Деление на ноль невозможно";
                return (a / (double)b).ToString(); // Возвращаем результат в виде строки
            }

            // Метод для отображения значений переменных
            public void DisplayValues()
            {
                Console.WriteLine($"a = {a}, b = {b}");
            }
        }

        class Program
        {
            static void Main()
            {
                // Создание объектов с разными конструкторами
                My_first_class obj1 = new My_first_class();           // Конструктор без аргументов
                My_first_class obj2 = new My_first_class(5);          // Конструктор с одним аргументом
                My_first_class obj3 = new My_first_class(8, 2);       // Конструктор с двумя аргументами

                // Тестирование методов
                Console.WriteLine("Объект 1:");
                obj1.DisplayValues();
                Console.WriteLine("Сумма: " + obj1.Sum());
                Console.WriteLine("Произведение: " + obj1.proizvedenie());
                Console.WriteLine("Разность: " + obj1.minus());
                Console.WriteLine("Деление: " + obj1.delenie());
                Console.WriteLine();

                Console.WriteLine("Объект 2:");
                obj2.DisplayValues();
                Console.WriteLine("Сумма: " + obj2.Sum());
                Console.WriteLine("Произведение: " + obj2.proizvedenie());
                Console.WriteLine("Разность: " + obj2.minus());
                Console.WriteLine("Деление: " + obj2.delenie());
                Console.WriteLine();

                Console.WriteLine("Объект 3:");
                obj3.DisplayValues();
                Console.WriteLine("Сумма: " + obj3.Sum());
                Console.WriteLine("Произведение: " + obj3.proizvedenie());
                Console.WriteLine("Разность: " + obj3.minus());
                Console.WriteLine("Деление: " + obj3.delenie());
            }
        }



    }


}

