using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace lab_12
{
    internal class lab_12
    {
        
        class POEZD
        {
            public int NumberTrain;
            public string Name_START;
            public string Name_END;
            public string TIME;
        }
        class STANCIYA
        {   
            public string Name_ST;
            public POEZD[] trains;
            public STANCIYA(int n)
            {
                trains = new POEZD[n];
            }
        }


        static void Main(string[] args)
        {
            bool exit = true;
            STANCIYA station = null;
            while (exit == true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Ввод данных");
                Console.WriteLine("2. Поезда с заданным пунктом назначения");
                Console.WriteLine("3. Поезда после заданного времени");
                Console.WriteLine("4. Выход");
                Console.Write("Выберите пункт: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Введите название станции: ");
                        string stationName = Console.ReadLine();
                        Console.Write("Введите количество поездов: ");
                        int n = int.Parse(Console.ReadLine());

                        station = new STANCIYA(n)
                        {
                            Name_ST = stationName
                        };
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine($"Ввод данных для поезда {i + 1}:");
                            station.trains[i] = new POEZD();

                            Console.Write("Введите номер поезда: ");
                            station.trains[i].NumberTrain = int.Parse(Console.ReadLine());

                            Console.Write("Введите пункт отправления: ");
                            station.trains[i].Name_START = Console.ReadLine();

                            Console.Write("Введите пункт назначения: ");
                            station.trains[i].Name_END = Console.ReadLine();

                            Console.Write("Введите время отправления: (например 14:30) ");
                            station.trains[i].TIME = Console.ReadLine();
                        }
                        Console.WriteLine("Данные успешно введены\n");
                        break;
                
                    case 2:
                        if (station == null)
                        {
                            Console.WriteLine("Сначала введите данные!\n");
                            break;
                        }
                        Console.Write("Введите пункт назначения: ");
                        string start_point = Console.ReadLine();
                        Console.WriteLine($"Поезда в пункт назначения {start_point}:");

                        foreach (var train in station.trains)
                        {
                            if (train.Name_END == start_point)
                            {
                                Console.WriteLine($"Номер поезда: {train.NumberTrain}, Время отправления: {train.TIME}");
                            }
                        }
                        Console.WriteLine();
                        break;

                    case 3:
                        if (station == null)
                        {
                            Console.WriteLine("Сначала введите данные!\n");
                            break;
                        }
                        Console.Write("Введите время в формате ЧЧ:ММ (например, 14:30): ");
                        string time_time = Console.ReadLine();
                        int Hours = int.Parse(time_time.Split(':')[0]);
                        int Minutes = int.Parse(time_time.Split(':')[1]);

                        Console.WriteLine($"Поезда, отправляющиеся после {time_time}:");
                        foreach (var train in station.trains)
                        {
                            int trainHours = int.Parse(train.TIME.Split(':')[0]);
                            int trainMinutes = int.Parse(train.TIME.Split(':')[1]);

                            if (trainHours > Hours || (trainHours == Hours && trainMinutes > Minutes))
                            {
                                Console.WriteLine($"Номер поезда: {train.NumberTrain}, Пункт назначения: {train.Name_END}, Время отправления: {train.TIME}");
                            }
                        }
                        Console.WriteLine();
                        break;

                    case 4:
                        exit = false;
                        Console.WriteLine("Выход из программы.");
                        break;

                    default:
                        Console.WriteLine("Неверный выбор, попробуйте снова.\n");
                        break;   
                }
            }

        }
    }
}
