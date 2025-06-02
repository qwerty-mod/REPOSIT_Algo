using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var graph = Console.ReadLine().Split();
        int n = int.Parse(graph[0]), m = int.Parse(graph[1]);

        var G = new List<int>[n + 1];
        for (int i = 1; i <= n; i++)
            G[i] = new List<int>();

        for (int i = 0; i < m; i++)
        {
            graph = Console.ReadLine().Split();
            int a = int.Parse(graph[0]), b = int.Parse(graph[1]);
            G[a].Add(b);
            G[b].Add(a);
        }

        var res = new List<int>();
        var visited = new bool[n + 1];
        var deg = new int[n + 1];
        var queue = new Queue<int>();

        for (int i = 1; i <= n; i++)
        {
            deg[i] = G[i].Count;
            if (deg[i] == 1)
                queue.Enqueue(i);
        }

        while (queue.Count > 0)
        {
            int leaf = queue.Dequeue();
            if (!visited[leaf])
            {
                res.Add(leaf);
                visited[leaf] = true;
                foreach (int neighbor in G[leaf])
                {
                    if (!visited[neighbor] && --deg[neighbor] == 1)
                        queue.Enqueue(neighbor);
                }
            }
        }

        for (int i = 1; i <= n; i++)
            if (!visited[i])
                res.Add(i);

        Console.WriteLine("Порядок закрытия станций:");
        foreach (var station in res)
            Console.WriteLine(station);
        Console.WriteLine("Общее количество лет: " + res.Count);
    }
}