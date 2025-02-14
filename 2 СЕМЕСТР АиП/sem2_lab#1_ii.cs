using System;
using System.Collections.Generic;

class PhoneNumberInfo
{
    public string Number;
    public string Operator;
    public int Year; 

    public PhoneNumberInfo(string number, string operatorName, int year)
    {
        Number = number;
        Operator = operatorName;
        Year = year;
    }
}

class Subscriber
{
    public string Name;
    public string City;
    public List<PhoneNumberInfo> PhoneNumbers;

    public Subscriber(string name, string city)
    {
        Name = name;
        City = city;
        PhoneNumbers = new List<PhoneNumberInfo>();
    }

    public void AddPhoneNumber(string number, string operatorName, int year)
    {
        PhoneNumbers.Add(new PhoneNumberInfo(number, operatorName, year));
    }

    public void PrintInfo()
    {
        Console.WriteLine("----------------------");
        Console.WriteLine($"| ФИО: {Name}");
        Console.WriteLine($"| Город: {City}");
        Console.WriteLine("| Телефоны:");
        foreach (var phone in PhoneNumbers)
        {
            Console.WriteLine($"| - {phone.Number} ({phone.Operator}, {phone.Year} г.)");
        }
        Console.WriteLine("----------------------");
    }
}

class Program
{
    static void Main()
    {
        List<Subscriber> phoneDirectory = new List<Subscriber>();

        while (true)
        {
            Console.WriteLine("1. Добавить запись");
            Console.WriteLine("2. Добавить номер существующему абоненту");
            Console.WriteLine("3. Выборка по оператору связи");
            Console.WriteLine("4. Выборка по году подключения");
            Console.WriteLine("5. Выборка по номеру телефона");
            Console.WriteLine("6. Выход");
            Console.Write("Выберите действие: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Введите ФИО: ");
                string name = Console.ReadLine();
                Console.Write("Введите город проживания: ");
                string city = Console.ReadLine();

                Subscriber subscriber = new Subscriber(name, city);

                Console.Write("Введите номер телефона: ");
                string phoneNumber = Console.ReadLine();
                Console.Write("Введите оператора связи: ");
                string operatorName = Console.ReadLine();
                Console.Write("Введите год подключения: ");
                int year = int.Parse(Console.ReadLine());

                subscriber.AddPhoneNumber(phoneNumber, operatorName, year);
                phoneDirectory.Add(subscriber);

                Console.WriteLine("---------------------------");
                Console.WriteLine("| Данные введены успешно! |");
                Console.WriteLine("---------------------------");
            }
            else if (choice == "2")
            {
                Console.Write("Введите ФИО абонента: ");
                string name = Console.ReadLine();
                var subscriber = phoneDirectory.Find(s => s.Name == name);
                if (subscriber != null)
                {
                    Console.Write("Введите номер телефона: ");
                    string phoneNumber = Console.ReadLine();
                    Console.Write("Введите оператора связи: ");
                    string operatorName = Console.ReadLine();
                    Console.Write("Введите год подключения: ");
                    int year = int.Parse(Console.ReadLine());

                    subscriber.AddPhoneNumber(phoneNumber, operatorName, year);

                    Console.WriteLine("---------------------------");
                    Console.WriteLine("| Номер добавлен успешно! |");
                    Console.WriteLine("---------------------------");
                }
                else
                {
                    Console.WriteLine("----------------------");
                    Console.WriteLine("| Абонент не найден | ");
                    Console.WriteLine("----------------------");
                }
            }
            else if (choice == "3")
            {
                Console.Write("Введите оператора связи: ");
                string op = Console.ReadLine();
                bool found = false;
                foreach (var subscriber in phoneDirectory)
                {
                    foreach (var phone in subscriber.PhoneNumbers)
                    {
                        if (phone.Operator == op)
                        {
                            subscriber.PrintInfo();
                            found = true;
                            break;
                        }
                    }
                }
                if (!found)
                {
                    Console.WriteLine("----------------------");
                    Console.WriteLine("| Записи отсутствуют |");
                    Console.WriteLine("----------------------");
                }
            }
            else if (choice == "4")
            {
                Console.Write("Введите год подключения: ");
                int year = int.Parse(Console.ReadLine());
                bool found = false;
                foreach (var subscriber in phoneDirectory)
                {
                    foreach (var phone in subscriber.PhoneNumbers)
                    {
                        if (phone.Year == year)
                        {
                            subscriber.PrintInfo();
                            found = true;
                            break;
                        }
                    }
                }
                if (!found)
                {
                    Console.WriteLine("----------------------");
                    Console.WriteLine("| Записи отсутствуют |");
                    Console.WriteLine("----------------------");
                }
            }
            else if (choice == "5")
            {
                Console.Write("Введите номер телефона: ");
                string number = Console.ReadLine();
                bool found = false;
                foreach (var subscriber in phoneDirectory)
                {
                    foreach (var phone in subscriber.PhoneNumbers)
                    {
                        if (phone.Number == number)
                        {
                            subscriber.PrintInfo();
                            found = true;
                            break;
                        }
                    }
                }
                if (!found)
                {
                    Console.WriteLine("----------------------");
                    Console.WriteLine("| Записи отсутствуют |");
                    Console.WriteLine("----------------------");
                }
            }
            else if (choice == "6")
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

