using System;
using System.Collections.Generic;

class Program
{
    // Класс телефон: номер, имя, оператор
    public class Phone
    {
        public string PhoneNumber;
        public string FullName;
        public string Operator;
    }

    static void Main()
    {
        
        List<Phone> phones = new List<Phone>
        {
            new Phone { PhoneNumber = "1234567890", FullName = "Ivanov Ivan", Operator = "MTS" },
            new Phone { PhoneNumber = "0987654321", FullName = "Petrov Petr", Operator = "Beeline" },
            new Phone { PhoneNumber = "1122334455", FullName = "Sidorov Sidr", Operator = "MTS" },
            new Phone { PhoneNumber = "2233445566", FullName = "Kuznetsov Kuzma", Operator = "Tele2" },
            new Phone { PhoneNumber = "3344556677", FullName = "Alexeev Alexey", Operator = "MTS" }
        };

        // Словарь для подсчета частоты использования операторов
        Dictionary<string, int> op_chastota = new Dictionary<string, int>();

        // Подсчет частоты операторов
        foreach (var phone in phones)
        {
            string phoneOperator = phone.Operator;

            if (op_chastota.ContainsKey(phoneOperator))
            {
                op_chastota[phoneOperator]++;
            }
            else
            {
                op_chastota[phoneOperator] = 1;
            }
        }

        // Поиск оператора с наибольшей частотой
        string PopularOperator = null;
        int max_chast = 0;

        foreach (var pair in op_chastota)
        {
            if (pair.Value > max_chast)
            {
                PopularOperator = pair.Key;
                max_chast = pair.Value;
            }
        }

        
        Console.WriteLine($"Самый используемый оператор: {PopularOperator} ({max_chast} шт.)");
    }
}

