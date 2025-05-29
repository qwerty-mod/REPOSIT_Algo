using System;
using System.Runtime.InteropServices;

unsafe class Program
{
    static void Main()
    {
        Console.WriteLine("Введите текст (пустая строка для завершения):");

        
        string[] lines = new string[100];
        int lineCount = 0;
        while (true)
        {
            string line = Console.ReadLine();
            if (string.IsNullOrEmpty(line)) break;
            lines[lineCount++] = line;
        }

        if (lineCount == 0)
        {
            Console.WriteLine("Текст не введен");
            return;
        }

        // Выделение памяти в стеке через stackalloc
        int* frequency = stackalloc int[256];

        
        for (int i = 0; i < 256; i++)
            frequency[i] = 0;

        
        for (int i = 0; i < lineCount; i++)
        {
            fixed (char* pLine = lines[i])
            {
                char* pChar = pLine;
                while (*pChar != '\0')
                {
                    frequency[*pChar]++;
                    pChar++;
                }
            }
        }

        // Поиск минимальной и максимальной частоты 
        int minFreq = int.MaxValue;
        int maxFreq = 0;

        for (int i = 0; i < 256; i++)
        {
            if (frequency[i] > 0)
            {
                if (frequency[i] < minFreq) minFreq = frequency[i];
                if (frequency[i] > maxFreq) maxFreq = frequency[i];
            }
        }

        
        Console.Write("\nСамые редкие символы (");
        Console.Write(minFreq);
        Console.Write(" раз): ");
        bool first = true;
        for (int i = 0; i < 256; i++)
        {
            if (frequency[i] == minFreq)
            {
                if (!first) Console.Write(", ");
                Console.Write($"'{(char)i}'");
                first = false;
            }
        }

        
        Console.Write("\nСамые частые символы (");
        Console.Write(maxFreq);
        Console.Write(" раз): ");
        first = true;
        for (int i = 0; i < 256; i++)
        {
            if (frequency[i] == maxFreq)
            {
                if (!first) Console.Write(", ");
                Console.Write($"'{(char)i}'");
                first = false;
            }
        }
        Console.WriteLine();
    }
}