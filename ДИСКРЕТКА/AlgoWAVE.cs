using System;
using System.Collections.Generic;

class WAVE_ALGO
{
    static void Main()
    {
        int[,] grid = new int[,]
        {
            { 0, 0, 0 },
            { 0, 0, 0 },
            { int.MaxValue, 0, 0 }
        };

        int[] from = { 0, 0 };
        int[] to = { 2, 2 };

        int? steps = FindShortestPathLength(from, to, grid);
        Console.WriteLine(steps.HasValue ? $"Расстояние: {steps}" : "Путь не найден");
    }

    
    static int? FindShortestPathLength(int[] start, int[] target, int[,] field)
    {
        int height = field.GetLength(0);
        int width = field.GetLength(1);

        bool[,] wasHere = new bool[height, width];
        int[,] stepCount = new int[height, width];
        for (int r = 0; r < height; r++)
            for (int c = 0; c < width; c++)
                stepCount[r, c] = int.MaxValue;

        var offsets = new List<(int dx, int dy)>
        {
            (-1, 0), (1, 0), (0, -1), (0, 1)
        };

        var cellsToExplore = new Queue<Tuple<int, int>>();
        cellsToExplore.Enqueue(Tuple.Create(start[0], start[1]));
        wasHere[start[0], start[1]] = true;
        stepCount[start[0], start[1]] = 0;

        while (cellsToExplore.Count > 0)
        {
            var point = cellsToExplore.Dequeue();
            int x = point.Item1;
            int y = point.Item2;

            if (x == target[0] && y == target[1])
                return stepCount[x, y];

            foreach (var (dx, dy) in offsets)
            {
                int nextX = x + dx;
                int nextY = y + dy;

                if (IsInside(nextX, nextY, height, width) &&
                    field[nextX, nextY] != int.MaxValue &&
                    !wasHere[nextX, nextY])
                {
                    wasHere[nextX, nextY] = true;
                    stepCount[nextX, nextY] = stepCount[x, y] + 1;
                    cellsToExplore.Enqueue(Tuple.Create(nextX, nextY));
                }
            }
        }

        return null;
    }

    
    static bool IsInside(int row, int col, int maxRow, int maxCol)
    {
        return row >= 0 && row < maxRow && col >= 0 && col < maxCol;
    }
}


