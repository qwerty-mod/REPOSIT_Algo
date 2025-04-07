using System;
using System.Collections.Generic;

class Program
{
    // Направления движения: вправо, вниз, влево, вверх
    static int[,] directions = new int[,] { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };

    static void Main()
    {
        int[,] field = {
            { 0, 0, 0, 0, 0 },
            { 0, -1, -1, 0, 0 },
            { 0, 0, 0, -1, 0 },
            { -1, -1, 0, 0, 0 },
            { 0, 0, 0, -1, 0 }
        };

        (int x, int y) start = (0, 0);
        (int x, int y) end = (4, 4);

        bool pathFound = WaveAlgorithm(field, start, end);

        Console.WriteLine("Стартовая точка: (" + start.x + ", " + start.y + ")");
        Console.WriteLine("Конечная точка: (" + end.x + ", " + end.y + ")");

        if (pathFound)
        {
            Console.WriteLine("Кратчайшее расстояние: " + field[end.x, end.y]);
        }
        else
        {
            Console.WriteLine("Невозможно достичь конечной точки.");
        }
        Console.WriteLine();
        PrintField(field, start, end);
        Console.WriteLine();
    }

    static bool WaveAlgorithm(int[,] field, (int x, int y) start, (int x, int y) end)
    {
        int rows = field.GetLength(0);
        int cols = field.GetLength(1);

        Queue<(int x, int y)> queue = new Queue<(int x, int y)>();
        queue.Enqueue(start);
        field[start.x, start.y] = 0;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            int step = field[current.x, current.y];

            for (int i = 0; i < 4; i++)
            {
                int nx = current.x + directions[i, 0];
                int ny = current.y + directions[i, 1];

                // Проверка границ и того, что клетка свободна и не старт
                if (nx >= 0 && nx < rows && ny >= 0 && ny < cols && field[nx, ny] == 0 && (nx, ny) != start)
                {
                    field[nx, ny] = step + 1;
                    queue.Enqueue((nx, ny));

                    if ((nx, ny) == end)
                        return true;
                }
            }
        }

        // Возвращаем true, если до финиша дошли (в нем не 0 и не -1)
        return field[end.x, end.y] > 0;
    }

    static void PrintField(int[,] field, (int x, int y) start, (int x, int y) end)
    {
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (i == start.x && j == start.y)
                {
                    Console.Write(" S ");
                }
                else if (i == end.x && j == end.y)
                {
                    Console.Write(" E ");
                }
                else if (field[i, j] == -1)
                {
                    Console.Write("██ ");
                }
                else if (field[i, j] == 0)
                {
                    Console.Write(" . ");
                }
                else
                {
                    Console.Write(field[i, j].ToString("00") + " ");
                }
            }
            Console.WriteLine();
        }
    }
}

