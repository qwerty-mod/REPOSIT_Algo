using System;

class Program
{
    static void Main()
    {
        
        int[,] graf = {
       //     1  2  3  4  5  6
            { 0, 0, 2, 3, 0, 0 }, // 1
            { 0, 0, 0, 10, 0, 0 }, // 2
            { 2, 0, 0, 7, 10, 15 }, // 3
            { 3, 10, 7, 0, 9, 0 }, // 4
            { 0, 0, 10, 9, 0, 1 }, // 5
            { 0, 0, 15, 0, 1, 0 }  // 6
        };

        Console.Write("Введите начальную вершину: ");
        int start = int.Parse(Console.ReadLine()) - 1;

        Console.Write("Введите конечную вершину: ");
        int end = int.Parse(Console.ReadLine()) - 1;

        int[] dist = new int[graf.GetLength(0)]; // Минимальные расстояния
        bool[] visit = new bool[graf.GetLength(0)]; // Посещенные вершины
        int[] prev = new int[graf.GetLength(0)]; // Предыдущие вершины

        const int INF = int.MaxValue;

        // Инициализация расстояний
        for (int i = 0; i < dist.Length; i++)
        {
            dist[i] = INF;
            prev[i] = -1;
        }
        dist[start] = 0;

        // Алгоритм Дейкстры
        for (int i = 0; i < dist.Length; i++)
        {
            int u = -1;
            for (int j = 0; j < dist.Length; j++)
                if (!visit[j] && (u == -1 || dist[j] < dist[u]))
                    u = j;

            if (dist[u] == INF)
                break;

            visit[u] = true;

            for (int v = 0; v < dist.Length; v++)
            {
                int weight = graf[u, v];
                if (weight > 0 && dist[u] + weight < dist[v])
                {
                    dist[v] = dist[u] + weight;
                    prev[v] = u;
                }
            }
        }

        
        if (dist[end] == INF)
        {
            Console.WriteLine("Пути не существует.");
        }
        else
        {
            Console.WriteLine("Кратчайший путь имеет длину: " + dist[end]);
            Console.Write("Путь: ");

            int current = end;
            string path = (current + 1).ToString(); // - для вывода в формате: x --> y --> z
            while (prev[current] != -1)
            {
                current = prev[current];
                path = (current + 1) + " --> " + path;
            }
            Console.WriteLine(path);
        }
    }
}

