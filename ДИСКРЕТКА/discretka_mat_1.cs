using System;

class Program
{
    static void Main()
    {
        int[,] graph = {
         //   1  2  3  4  5
            { 0, 1, 0, 0, 0 }, // 1
            { 1, 0, 1, 0, 0 }, // 2
            { 0, 1, 0, 0, 0 }, // 3
            { 0, 0, 0, 0, 1 }, // 4
            { 0, 0, 0, 1, 0 }  // 5
        };

        bool[] visit = new bool[5]; // массив, который отслеживает, какие вершины уже посещены (true - посещена, false - не посещена).
        int components = 0;

        for (int i = 0; i < 5; i++) // пройдём по всем вершинам графа
        {
            if (!visit[i]) // если не посещена вершина то это новая компонента
            {
                components++;
                int[] nabor = new int[5]; //храним вершины для обхода
                int Point = 0; // верхушка набора
                nabor[Point++] = i; // с i-вершины начинаем обход

                while (Point > 0) // пока в наборе есть вершины 
                {
                    int Vershina = nabor[--Point]; // достаём верхний элемент из набора
                    if (!visit[Vershina])
                    {
                        visit[Vershina] = true;
                        for (int j = 0; j < 5; j++) // находим соседей вершины
                        {
                            if (graph[Vershina, j] == 1 && !visit[j])  //Если есть связь и j не посещена — сосед Vershina.
                            {
                                nabor[Point++] = j;
                            }
                        }
                    }
                }
            }
        }

        Console.WriteLine("Количество компонентов связанности: " + components);
    }
}

