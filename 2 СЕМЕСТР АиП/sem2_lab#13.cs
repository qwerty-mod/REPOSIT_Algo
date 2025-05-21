using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.Write("Введите путь к входному файлу: ");
        string input = Console.ReadLine();

        Console.Write("Введите путь к выходному файлу: ");
        string output = Console.ReadLine();

        if (!File.Exists(input))
        {
            Console.WriteLine("Файл не найден: " + input);
            return;
        }

        // Регулярное выражение для поиска чисел
        Regex r = new Regex(@"\d+");

        try
        {
            using (StreamReader reader = new StreamReader(input))

            using (StreamWriter writer = new StreamWriter(output))

            {
                string stroka;
                while ((stroka = reader.ReadLine()) != null)
                {
                    MatchCollection matches = r.Matches(stroka);
                    bool flag = false;

                    foreach (Match match in matches)
                    {
                        if (int.TryParse(match.Value, out int number) && number % 2 == 0)
                        {
                            flag = true;
                            break;
                        }
                    }

                    if (flag)
                    {
                        writer.WriteLine(stroka);
                    }
                }
            }

            Console.WriteLine("Результат сохранён в: " + output);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка: " + ex.Message);
        }
    }
}


