using System;

class Program
{
    static void Main()
    {
        int[,] matrica = {
            { 0, -1, 4, 0, 0 },
            { 0, 0, 3, 2, 2 },
            { 0, 0, 0, 0, 0 },
            { 0, 1, 5, 0, 0 },
            { 0, 0, 0, -3, 0 }
        };

        int kolvoVershin = matrica.GetLength(0);
        int start = 0;
        int bolshoeChislo = 1000000;

        int[] dist = new int[kolvoVershin];
        for (int i = 0; i < kolvoVershin; i++)
        {
            dist[i] = bolshoeChislo;
        }
        dist[start] = 0;

        for (int k = 0; k < kolvoVershin - 1; k++)
        {
            for (int i = 0; i < kolvoVershin; i++)
            {
                for (int j = 0; j < kolvoVershin; j++)
                {
                    if (matrica[i, j] != 0)
                    {
                        if (dist[i] != bolshoeChislo && dist[i] + matrica[i, j] < dist[j])
                        {
                            dist[j] = dist[i] + matrica[i, j];
                        }
                    }
                }
            }
        }

        bool OTR_ciklEst = false;
        for (int i = 0; i < kolvoVershin; i++)
        {
            for (int j = 0; j < kolvoVershin; j++)
            {
                if (matrica[i, j] != 0)
                {
                    if (dist[i] != bolshoeChislo && dist[i] + matrica[i, j] < dist[j])
                    {
                        OTR_ciklEst = true;
                    }
                }
            }
        }

        if (OTR_ciklEst)
        {
            Console.WriteLine("Отрицательный цикл есть");
        }
        else
        {
            for (int i = 0; i < kolvoVershin; i++)
            {
                Console.WriteLine("От вершины " + start + " до " + i + " путь = " + dist[i]);
            }
        }

        Console.ReadLine();
    }
}
