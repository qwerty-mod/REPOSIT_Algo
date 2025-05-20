using System;

class TravelingSalesman
{
    static void Main()
    {
        
        int[,] distances = {
            {0, 10, 15, 20},
            {10, 0, 35, 25},
            {15, 35, 0, 30},
            {20, 25, 30, 0}
        };

        bool[] visited = new bool[4];
        int[] path = new int[4];
        int[] bestPath = new int[4];
        int minDistance = int.MaxValue;

        
        path[0] = 0;
        visited[0] = true;

        
        BestP(distances, visited, path, bestPath, ref minDistance, 1, 0);

        Console.WriteLine("Лучший маршрут:");
        for (int i = 0; i < 4; i++)
        {
            Console.Write(bestPath[i] + " -> ");
        }
        Console.WriteLine(bestPath[0]); 

        Console.WriteLine("Общая длина: " + minDistance);
    }

    static void BestP(int[,] dist, bool[] vis, int[] curPath, int[] bestPath,
                           ref int minDist, int step, int curDist)
    {
        
        if (step == 4)
        {
            
            int totalDist = curDist + dist[curPath[3], curPath[0]];
            if (totalDist < minDist)
            {
                minDist = totalDist;
                Array.Copy(curPath, bestPath, 4);
            }
            return;
        }

        
        for (int city = 0; city < 4; city++)
        {
            if (!vis[city])
            {
                vis[city] = true;
                curPath[step] = city;

                BestP(dist, vis, curPath, bestPath, ref minDist,
                           step + 1, curDist + dist[curPath[step - 1], city]);

                vis[city] = false;
            }
        }
    }
}