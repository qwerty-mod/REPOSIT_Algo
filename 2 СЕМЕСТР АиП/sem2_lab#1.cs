using System;

class Program
{
    static void Main()
    {
        // ТЕЛЕФОННЫЙ СПРАВОЧНИК //
        string[] names = new string[100];
        string[] phoneNumbers = new string[100];
        string[] operators = new string[100];
        int[] years = new int[100];
        string[] cities = new string[100];
        int count = 0;

        while (true)
        {
            Console.WriteLine("1. Добавить запись");
            Console.WriteLine("2. Выборка по оператору связи");
            Console.WriteLine("3. Выборка по году подключения");
            Console.WriteLine("4. Выборка по номеру телефона");
            Console.WriteLine("5. Выход");
            Console.Write("Выберите действие: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                if (count >= 10)
                {
                    Console.WriteLine("Справочник заполнен!");
                    continue;
                }

                Console.Write("Введите ФИО: ");
                names[count] = Console.ReadLine();
                Console.Write("Введите номер телефона: ");
                phoneNumbers[count] = Console.ReadLine();
                Console.Write("Введите оператора связи: ");
                operators[count] = Console.ReadLine();
                Console.Write("Введите год подключения: ");
                years[count] = int.Parse(Console.ReadLine());
                Console.Write("Введите город проживания: ");
                cities[count] = Console.ReadLine();

                count++;
            }
            else if (choice == "2")
            {
                Console.Write("Введите оператора связи: ");
                string op = Console.ReadLine();
                for (int i = 0; i < count; i++)
                {
                    if (operators[i] == op)
                    {
                        Console.WriteLine("----------------------");
                        Console.WriteLine($"| ФИО: {names[i]}");
                        Console.WriteLine($"| Номер: {phoneNumbers[i]}");
                        Console.WriteLine($"| Оператор: {operators[i]}");
                        Console.WriteLine($"| Год подключения: {years[i]}");
                        Console.WriteLine($"| Город: {cities[i]}");
                        Console.WriteLine("----------------------");
                    }
                    else
                    {
                        Console.WriteLine("----------------------");
                        Console.WriteLine("| Записи отсутствуют |");
                        Console.WriteLine("----------------------");
                    }
                }
            }
            else if (choice == "3")
            {
                Console.Write("Введите год подключения: ");
                int year = int.Parse(Console.ReadLine());
                for (int i = 0; i < count; i++)
                {
                    if (years[i] == year)
                    {
                        Console.WriteLine("----------------------");
                        Console.WriteLine($"| ФИО: {names[i]}");
                        Console.WriteLine($"| Номер: {phoneNumbers[i]}");
                        Console.WriteLine($"| Оператор: {operators[i]}");
                        Console.WriteLine($"| Год подключения: {years[i]}");
                        Console.WriteLine($"| Город: {cities[i]}");
                        Console.WriteLine("----------------------");
                    }
                }
            }
            else if (choice == "4")
            {
                Console.Write("Введите номер телефона: ");
                string number = Console.ReadLine();
                for (int i = 0; i < count; i++)
                {
                    if (phoneNumbers[i] == number)
                    {
                        Console.WriteLine("----------------------");
                        Console.WriteLine($"| ФИО: {names[i]}");
                        Console.WriteLine($"| Номер: {phoneNumbers[i]}");
                        Console.WriteLine($"| Оператор: {operators[i]}");
                        Console.WriteLine($"| Год подключения: {years[i]}");
                        Console.WriteLine($"| Город: {cities[i]}");
                        Console.WriteLine("----------------------");
                    }
                }
            }
            else if (choice == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("| Код действия введён не правильно!!! |");
                Console.WriteLine("---------------------------------------");
            }
        }
    }
}

