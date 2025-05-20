using System; 
using System.Collections.Generic; 
using System.Linq; 


class mobila
{
    public string marka; 
    public int godik; 
    public string strana; 
}


class Start
{
    static void Main()
    {
        List<mobila> daList = new List<mobila>(); 

        while (true) 
        {
            
            Console.WriteLine("\n--- Меню ---"); 
            Console.WriteLine("1. Добавить телефон"); 
            Console.WriteLine("2. Сгруппировать все телефоны по стране"); 
            Console.WriteLine("3. Выдать телефоны с заданным годом выпуска"); 
            Console.WriteLine("4. Сгруппировать телефоны по марке"); 
            Console.WriteLine("5. Выйти"); 
            Console.Write("Выбери действие: "); 

            string vibor = Console.ReadLine(); 

            if (vibor == "1") 
            {
                mobila f = new mobila(); 

                Console.Write("Введи марку: "); 
                f.marka = Console.ReadLine(); 

                Console.Write("Введи год выпуска: "); 
                f.godik = int.Parse(Console.ReadLine()); 

                Console.Write("Введи страну использования: "); 
                f.strana = Console.ReadLine(); 

                daList.Add(f); 
                Console.WriteLine("Телефон добавлен!");
            }
            else if (vibor == "2") 
            {
                
                var grupStrana = daList.GroupBy(t => t.strana); // LINQ группировка

                foreach (var grup in grupStrana) 
                {
                    Console.WriteLine($"\nСтрана: {grup.Key}"); 
                    foreach (var t in grup) 
                    {
                        Console.WriteLine($"Марка: {t.marka}, Год: {t.godik}"); 
                    }
                }
            }
            else if (vibor == "3") 
            {
                Console.Write("Введи нужный год: "); 
                int godZapros = int.Parse(Console.ReadLine()); 

                
                var fonesByYear = daList.Where(f => f.godik == godZapros); // LINQ фильтрация

                foreach (var t in fonesByYear) 
                {
                    Console.WriteLine($"Марка: {t.marka}, Страна: {t.strana}");
                }
            }
            else if (vibor == "4") 
            {
                
                var grupMarka = daList.GroupBy(f => f.marka); // LINQ группировка

                foreach (var grup in grupMarka) 
                {
                    Console.WriteLine($"\nМарка: {grup.Key}"); 
                    foreach (var t in grup) 
                    {
                        Console.WriteLine($"Год: {t.godik}, Страна: {t.strana}"); 
                    }
                }
            }
            else if (vibor == "5") 
            {
                Console.WriteLine(); 
                break; 
            }
            else 
            {
                Console.WriteLine("Неправильный выбор");
            }
        }
    }
}

