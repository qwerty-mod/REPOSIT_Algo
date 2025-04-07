using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<string> spisokSlov = new List<string>
        {
            "море", "гора", "молоко", "лес", "машина", "река", "мята"
        };

        // Лямбда-выражение для отбора слов на "м"
        var tolkoMslova = spisokSlov.Where(slovo => slovo.StartsWith("м")).ToList();

        
        Console.WriteLine("Слова которые начинаются на букву 'м' :");
        Console.WriteLine();
        foreach (var slovich in tolkoMslova)
        {
            Console.WriteLine(slovich);
        }
        Console.WriteLine();
    }
}
