using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[,] graf = {
        //    1  2  3  4  5  6
            { 0, 0, 2, 3, 0, 0 },  //1
            { 0, 0, 0, 10, 0, 0 }, //2
            { 2, 0, 0, 7, 10, 15}, //3
            { 3, 10, 7, 0, 9, 0 }, //4
            { 0, 0, 10, 9, 0, 1 }, //5
            { 0, 0, 15, 0, 1, 0 }  //6
        };

        Console.WriteLine("Минимальная сумма весов (Primo): " + PrimoAlgoritm(graf));
        Console.WriteLine("Минимальная сумма весов (Kruskala): " + KruskalaAlgoritm(graf));
    }

    static int PrimoAlgoritm(int[,] graf)
    {
        int dlina = graf.GetLength(0); // кол-во вершин
        bool[] visit = new bool[dlina]; // Массив посещённых вершин
        int[] minRebro = new int[dlina]; // Массив минимальных рёбер
        for (int i = 0; i < dlina; i++) minRebro[i] = int.MaxValue; // Инициализация минимальных рёбер как бесконечность
        minRebro[0] = 0; // Начинаем с вершины 0
        int summaVesov = 0; 

        
        for (int i = 0; i < dlina; i++)
        {
            int minVershina = -1;
            // Находим вершину с минимальным ребром, которая ещё не посещена
            for (int j = 0; j < dlina; j++)
            {
                if (!visit[j] && (minVershina == -1 || minRebro[j] < minRebro[minVershina]))
                {
                    minVershina = j;
                }
            }

            visit[minVershina] = true; // Помечаем эту вершину как посещённую
            summaVesov += minRebro[minVershina]; // Добавляем вес к общей сумме

            // Обновляем минимальные рёбра для соседних вершин
            for (int j = 0; j < dlina; j++)
            {
                if (graf[minVershina, j] != 0 && !visit[j] && graf[minVershina, j] < minRebro[j])
                {
                    minRebro[j] = graf[minVershina, j];
                }
            }
        }

        return summaVesov; 
    }

    static int KruskalaAlgoritm(int[,] graf)
    {
        int dlina = graf.GetLength(0);
        List<(int, int, int)> rebra = new List<(int, int, int)>();

        // Заполняем список рёбер: (стоимость, начальная вершина, конечная вершина)
        for (int i = 0; i < dlina; i++)
        {
            for (int j = i + 1; j < dlina; j++)
            {
                if (graf[i, j] != 0)
                {
                    rebra.Add((graf[i, j], i, j));
                }
            }
        }

        // Сортировка рёбер по стоимости
        rebra.Sort((a, b) => a.Item1.CompareTo(b.Item1));

        int[] roditel = new int[dlina];
        for (int i = 0; i < dlina; i++) roditel[i] = i;

        // Функция для нахождения "корня" компоненты
        int Nayti(int v)
        {
            if (roditel[v] == v) return v;
            return roditel[v] = Nayti(roditel[v]);
        }

        // Функция для объединения двух компонентов
        void Obedinit(int a, int b)
        {
            a = Nayti(a);
            b = Nayti(b);
            if (a != b) roditel[b] = a;
        }

        int summaVesov = 0;

        // Проходим по рёбрам и объединяем компоненты
        foreach (var (stoimost, u, v) in rebra)
        {
            if (Nayti(u) != Nayti(v))
            {
                summaVesov += stoimost;
                Obedinit(u, v);
            }
        }

        return summaVesov;
    }
}




