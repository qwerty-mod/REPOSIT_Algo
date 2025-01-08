using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace lab_13
{
    internal class Program
    {
        class Animal
        {
            public string Name;
        }
        class Birds : Animal
        {

            public string place; // где обитают
            public string place_winter; // куда летят зимовать
            public override string ToString()
            {
                return $"Имя: {Name}, Место обитания: {place}, Место зимовки: {place_winter}";
            }
        }
        class Mleko : Animal
        {
            public string place; // где обитают
            public string weight; // вес
            public override string ToString()
            {
                return $"Имя: {Name}, Место обитания: {place}, Вес: {weight}";
            }
        }
        static void Main(string[] args)
        {
            bool exit = true;
            int selection = 0;
            Birds[] mass = null;
            Mleko[] mass2 = null;
            while (exit)
            {
                Console.WriteLine("1. Заполнить данные");
                Console.WriteLine("2. Выборка по месту обитания");
                Console.WriteLine("3. Выборка по месту зимовки птиц");
                Console.WriteLine("4. Выборка по весу животного(млекопитающего)");
                Console.WriteLine("5. Выход");
                Console.WriteLine();
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Укажите количество птиц ");
                        int n = int.Parse(Console.ReadLine());
                        Console.WriteLine("Укажите количество млекопитающих ");
                        int n1 = int.Parse(Console.ReadLine());
                        selection = n;
                        mass = new Birds[n];
                        mass2 = new Mleko[n1];
                        for (int i = 0; i < n; i++) // Птицы
                        {
                            Console.WriteLine($"Заполните данные о птице под номером {i + 1}: ");
                            mass[i] = new Birds();
                            Console.Write("Наименование птицы: ");
                            mass[i].Name = Console.ReadLine();
                            Console.Write("Место обитания: ");
                            mass[i].place = Console.ReadLine();
                            Console.Write("Место зимовки: ");
                            mass[i].place_winter = Console.ReadLine();
                        }

                        for (int i = 0; i < n1; i++) // Млекопитающие
                        {
                            Console.WriteLine($"Заполните данные о млекопитающем под номером {i + 1}: ");
                            mass2[i] = new Mleko();
                            Console.Write("Наименование млекопитающего: ");
                            mass2[i].Name = Console.ReadLine();
                            Console.Write("Место обитания: ");
                            mass2[i].place = Console.ReadLine();
                            Console.Write("Вес животного: ");
                            mass2[i].weight = Console.ReadLine();
                        }
                        Console.WriteLine();
                        Console.WriteLine("Данные успешно заполнены!!!");
                        break;

                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("Напишите место обитания животного");
                        string str = Console.ReadLine();
                        Console.WriteLine("Результаты выборки (птицы):");
                        foreach (var bird in mass)
                        {
                            if (bird != null && bird.place == str)
                                Console.WriteLine(bird);
                        }

                        Console.WriteLine("Результаты выборки (млекопитающие):");
                        foreach (var mleko in mass2)
                        {
                            if (mleko != null && mleko.place == str)
                                Console.WriteLine(mleko);
                        }
                        break;
                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("Напишите место зимовки ");
                        string str1 = Console.ReadLine();
                        Console.WriteLine("Результаты выборки (птицы):");
                        foreach (var bird in mass)
                        {
                            if (bird != null && bird.place_winter == str1)
                                Console.WriteLine(bird);
                        }
                        break;
                    case 4:
                        Console.WriteLine();
                        Console.WriteLine("Укажите вес животного(млекопитающего)");
                        string str2 = Console.ReadLine();
                        Console.WriteLine("Результаты выборки: ");
                        foreach (var bird in mass2)
                        {
                            if (bird != null && bird.weight == str2)
                                Console.WriteLine(bird);
                        }
                        break;
                    case 5:
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Такого номера-выбора нет, выберите корректный пункт");
                        Console.WriteLine();
                        break;
                }
            }
            
        }
    }
}
