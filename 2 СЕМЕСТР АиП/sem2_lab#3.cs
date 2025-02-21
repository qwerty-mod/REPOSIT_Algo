using System;
using System.Collections.Generic; 

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите выражение:"); 
        string str = Console.ReadLine(); 

        Stack<char> stack = new Stack<char>(); 
        bool flag = true; // для проверки корректности расстановки скобок

        for (int i = 0; i < str.Length; i++) // Проходим по каждому символу выражения
        {
            char c = str[i]; 

            if (c == '(' || c == '[' || c == '{') 
            {
                stack.Push(c); // Добавляем скобку в стек
            }
            else if (c == ')' || c == ']' || c == '}') 
            {
                if (stack.Count == 0) // Если стек пуст, значит, скобка не имеет пары
                {
                    flag = false;
                    break;
                }

                char open = stack.Pop(); // Получаем верхний элемент стека и удаляем его

                if ((c == ')' && open != '(') || // соответствие скобок
                    (c == ']' && open != '[') ||
                    (c == '}' && open != '{'))
                {
                    flag = false; // Если скобки не совпадают, устанавливаем флаг ошибки
                    break; 
                }
            }
        }

        if (flag && stack.Count == 0) 
        {
            Console.WriteLine("Скобки расставлены правильно"); 
        }
        else
        {
            Console.WriteLine("Скобки расставлены неправильно"); 
        }
    }
}


