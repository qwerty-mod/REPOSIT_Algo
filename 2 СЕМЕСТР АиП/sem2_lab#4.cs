using System;
using System.Collections;

class Program
{
    static void Main()
    {
        
        Console.WriteLine("Введите выражение в постфиксной записи:");
        
        
        string input = Console.ReadLine();
        
        // разбиваем строку на массив элементов (числа и операторы) разделяя по пробелу
        string[] tokens = input.Split(' ');
        
        // хранения операндов
        Stack stack = new Stack();

        
        foreach (string token in tokens)
        {
            // если это число помещаем его в стек
            if (int.TryParse(token, out int number))
            {
                stack.Push(number);
            }
            // Если это оператор ( +, -, *, / )
            else if (token == "*" || token == "+" || token == "-" || token == "/")
            {
                // есть ли в стеке хотя бы два операнда
                if (stack.Count < 2)
                {
                    Console.WriteLine("Ошибка: Недостаточно операндов для операции");
                    return;
                }
                
                // извлекаем два верхних числа из стека
                int b = (int)stack.Pop();
                int a = (int)stack.Pop();
                
                // деление на ноль
                if (token == "/" && b == 0)
                {
                    Console.WriteLine("Ошибка: Деление на ноль");
                    return;
                }
                
                // выполняем операцию и помещаем результат обратно в стек
                int result = token == "*" ? a * b : token == "+" ? a + b : token == "-" ? a - b : a / b;
                stack.Push(result);
            }
            // некорректный символ
            else
            {
                Console.WriteLine("Ошибка: Некорректный символ в выражении");
                return;
            }
        }

        // в стеке один элемент? да - выражение корректно
        if (stack.Count != 1)
        {
            Console.WriteLine("Ошибка: Некорректное выражение, лишние операнды или операции");
        }
        else
        {
            // Выводим результат
            Console.WriteLine("Результат: " + stack.Pop());
        }
    }
}