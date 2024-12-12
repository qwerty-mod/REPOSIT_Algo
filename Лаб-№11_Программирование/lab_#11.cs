using System;

class Student
{
    public string FullName;   // ФИО ученика
    public string BirthYear;  // Год рождения в формате дд.мм.гггг
    public string MotherName; // ФИО мамы
    public string FatherName; // ФИО папы
    public string Address;    // Адрес (улица, дом, квартира)

    public Student(string fullName, string birthYear, string motherName = "", string fatherName = "", string address = "") // шаблон обьектов
    {
        FullName = fullName;
        BirthYear = birthYear;
        MotherName = motherName;
        FatherName = fatherName;
        Address = address;
    }
}










class Program
{
    static Student[] students = new Student[100]; // Массив учеников
    static int studentCount = 0;  // Количество учеников в массиве

    // Метод для заполнения данных ученика
    static void zapolnenie()
    {
        if (studentCount >= 100)
        {
            Console.WriteLine("Массив учеников переполнен.");
            return;
        }

        Console.Write("Введите ФИО ученика: ");
        string fullName = Console.ReadLine();

        Console.Write("Введите год рождения (дд.мм.гггг): ");
        string birthYear = Console.ReadLine();

        Console.Write("Введите ФИО мамы (оставьте пустым, если не хотите указывать): ");
        string motherName = Console.ReadLine();

        Console.Write("Введите ФИО папы (оставьте пустым, если не хотите указывать): ");
        string fatherName = Console.ReadLine();

        Console.Write("Введите адрес (улица, дом, квартира): ");
        string address = Console.ReadLine();

        students[studentCount++] = new Student(fullName, birthYear, motherName, fatherName, address);
    }










    // Метод для модификации данных ученика по ФИО
    static void Modifika()
    {
        Console.Write("Введите ФИО ученика для изменения: ");
        string fullName = Console.ReadLine();

        bool found = false;
        for (int i = 0; i < studentCount; i++)
        {
            if (students[i].FullName == fullName)
            {
                found = true;
                Console.WriteLine("Ученик найден. Введите новые данные.");

                Console.Write("Новый год рождения (оставьте пустым, если не хотите изменять): ");
                string newBirthYear = Console.ReadLine();
                if (!string.IsNullOrEmpty(newBirthYear)) students[i].BirthYear = newBirthYear;

                Console.Write("Новое ФИО мамы (оставьте пустым, если не хотите изменять): ");
                string newMotherName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newMotherName)) students[i].MotherName = newMotherName;

                Console.Write("Новое ФИО папы (оставьте пустым, если не хотите изменять): ");
                string newFatherName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newFatherName)) students[i].FatherName = newFatherName;

                Console.Write("Новый адрес (оставьте пустым, если не хотите изменять): ");
                string newAddress = Console.ReadLine();
                if (!string.IsNullOrEmpty(newAddress)) students[i].Address = newAddress;

                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Ученик с таким ФИО не найден.");
        }
    }










    // Метод для поиска учеников по году рождения
    static void SearchGOD()
    {
        Console.Write("Введите год рождения (дд.мм.гггг) для поиска: ");
        string searchYear = Console.ReadLine();

        bool found = false;
        for (int i = 0; i < studentCount; i++)
        {
            if (students[i].BirthYear == searchYear)
            {
                found = true;
                Console.WriteLine($"Ученик: {students[i].FullName}, Адрес: {students[i].Address}");
            }
        }

        if (!found)
        {
            Console.WriteLine("Учеников с таким годом рождения не найдено.");
        }
    }











    // Метод для поиска учеников по первой букве ФИО
    static void SearchBUKVA()
    {
        Console.Write("Введите первую букву ФИО для поиска: ");
        char letter = Char.ToUpper(Console.ReadLine()[0]);

        bool found = false;
        for (int i = 0; i < studentCount; i++)
        {
            if (students[i].FullName[0] == letter)
            {
                found = true;
                Console.WriteLine($"Ученик: {students[i].FullName}, Адрес: {students[i].Address}");
            }
        }

        if (!found)
        {
            Console.WriteLine("Учеников с такой буквы не найдено.");
        }
    }












    // Метод для поиска учеников по улице
    static void SearchStreet()
    {
        Console.Write("Введите улицу для поиска: ");
        string street = Console.ReadLine().ToLower();

        bool found = false;
        for (int i = 0; i < studentCount; i++)
        {
            if (students[i].Address.ToLower().Contains(street))
            {
                found = true;
                Console.WriteLine($"Ученик: {students[i].FullName}, Адрес: {students[i].Address}");
            }
        }

        if (!found)
        {
            Console.WriteLine("Учеников, проживающих на данной улице, не найдено.");
        }
    }











    // Метод для отображения меню
    static void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Заполнить данные ученика");
            Console.WriteLine("2. Модифицировать данные ученика");
            Console.WriteLine("3. Найти учеников по году рождения");
            Console.WriteLine("4. Найти учеников по первой букве ФИО");
            Console.WriteLine("5. Найти учеников по улице");
            Console.WriteLine("6. Выход");
            Console.Write("Выберите действие: ");
            int vibor = int.Parse(Console.ReadLine());

            switch (vibor)
            {
                case 1:
                    zapolnenie();
                    break;
                case 2:
                    Modifika();
                    break;
                case 3:
                    SearchGOD();
                    break;
                case 4:
                    SearchBUKVA();
                    break;
                case 5:
                    SearchStreet();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Неверный выбор, попробуйте снова.");
                    break;
            }
        }
    }





    static void Main(string[] args)
    {
        ShowMenu();  // Вызываем главное меню
    }
}

