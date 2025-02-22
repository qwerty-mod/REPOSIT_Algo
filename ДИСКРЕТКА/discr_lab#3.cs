using System;

class Program
{
    static int vremya = 0; // Время входа
    static int[,] graf = {
    //    1  2  3  4  5
        { 0, 1, 0, 0, 1 }, // 1
        { 1, 0, 0, 1, 0 }, // 2
        { 0, 0, 0, 1, 0 }, // 3
        { 0, 1, 1, 0, 1 }, // 4
        { 1, 0, 0, 1, 0 }  // 5
    };

    static int vershiny = 5; // Количество вершин
    static bool[] posesh = new bool[5]; // Посещённые вершины
    static int[] vhod = new int[5]; // Время входа
    static int[] minvhod = new int[5]; // Минимальное достижимое время входа
    static int[] rodak = new int[5]; // Родитель

    static void Main()
    {
        for (int i = 0; i < vershiny; i++)
        {
            vhod[i] = -1; // Все вершины не посещены
            minvhod[i] = -1;
            rodak[i] = -1;
        }

        for (int i = 0; i < vershiny; i++)
            if (!posesh[i]) GlubPoisk(i);

        Console.ReadLine(); 
    }

    static void GlubPoisk(int u)
    {
        posesh[u] = true;
        vhod[u] = minvhod[u] = ++vremya; // Время входа

        for (int v = 0; v < vershiny; v++)
        {
            if (graf[u, v] == 1) // Если есть ребро u - v
            {
                if (!posesh[v]) // Если v не посещена
                {
                    rodak[v] = u;
                    GlubPoisk(v);

                    minvhod[u] = Math.Min(minvhod[u], minvhod[v]); // Обновляем minvhod

                    if (minvhod[v] > vhod[u]) // Если это мост
                        Console.WriteLine($"Мост найден: {u + 1} - {v + 1}");
                }
                else if (v != rodak[u]) // Обновляем minvhod, если нашли обратное ребро
                {
                    minvhod[u] = Math.Min(minvhod[u], vhod[v]);
                }
            }
        }
    }
}




