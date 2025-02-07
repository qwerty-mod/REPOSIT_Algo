using System;

class Subscriber
{
    public string Name;
    public string PhoneNumber;
    public string Operator;
    public int Year;
    public string City;

    public Subscriber(string name, string phoneNumber, string operatorName, int year, string city)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Operator = operatorName;
        Year = year;
        City = city;
    }

    public void PrintInfo()
    {
        Console.WriteLine("----------------------");
        Console.WriteLine($"| ФИО: {Name}");
        Console.WriteLine($"| Номер: {PhoneNumber}");
        Console.WriteLine($"| Оператор: {Operator}");
        Console.WriteLine($"| Год подключения: {Year}");
        Console.WriteLine($"| Город: {City}");
        Console.WriteLine("----------------------");
    }
}

class Program
{
    static void Main()
    {
        Subscriber[] phoneDirectory = new Subscriber[10];
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
                if (count >= phoneDirectory.Length)
                {
                    Console.WriteLine("Справочник заполнен!");
                    continue;
                }

                Console.Write("Введите ФИО: ");
                string name = Console.ReadLine();
                Console.Write("Введите номер телефона: ");
                string phoneNumber = Console.ReadLine();
                Console.Write("Введите оператора связи: ");
                string operatorName = Console.ReadLine();
                Console.Write("Введите год подключения: ");
                int year = int.Parse(Console.ReadLine());
                Console.Write("Введите город проживания: ");
                string city = Console.ReadLine();

                phoneDirectory[count] = new Subscriber(name, phoneNumber, operatorName, year, city);
                count++;
                Console.WriteLine("---------------------------");
                Console.WriteLine("| Данные введены успешно! |");
                Console.WriteLine("---------------------------");
            }
            else if (choice == "2")
            {
                Console.Write("Введите оператора связи: ");
                string op = Console.ReadLine();
                bool flag = false;
                for (int i = 0; i < count; i++)
                {
                    if (phoneDirectory[i].Operator == op)
                    {
                        phoneDirectory[i].PrintInfo();
                        flag = true;
                    }
                }
                if (!flag)
                {
                    Console.WriteLine("----------------------");
                    Console.WriteLine("| Записи отсутствуют |");
                    Console.WriteLine("----------------------");
                }
            }
            else if (choice == "3")
            {
                Console.Write("Введите год подключения: ");
                int year = int.Parse(Console.ReadLine());
                bool flag2 = false;
                for (int i = 0; i < count; i++)
                {
                    if (phoneDirectory[i].Year == year)
                    {
                        phoneDirectory[i].PrintInfo();
                        flag2 = true;
                    }
                }
                if (!flag2)
                {
                    Console.WriteLine("----------------------");
                    Console.WriteLine("| Записи отсутствуют |");
                    Console.WriteLine("----------------------");
                }
            }
            else if (choice == "4")
            {
                Console.Write("Введите номер телефона: ");
                string number = Console.ReadLine();
                bool flag3 = false;
                for (int i = 0; i < count; i++)
                {
                    if (phoneDirectory[i].PhoneNumber == number)
                    {
                        phoneDirectory[i].PrintInfo();
                        flag3 = true;
                    }
                }
                if (!flag3)
                {
                    Console.WriteLine("----------------------");
                    Console.WriteLine("| Записи отсутствуют |");
                    Console.WriteLine("----------------------");
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

