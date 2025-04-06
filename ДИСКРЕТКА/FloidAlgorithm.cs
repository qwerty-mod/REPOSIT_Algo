using System;

namespace FloidAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int[,] test = {
                { 0, 3, int.MaxValue, 7 },
                { 8, 0, 2, int.MaxValue },
                { 5, int.MaxValue, 0, 1 },
                { 2, int.MaxValue, int.MaxValue, 0 }
            };

            
            FloidAlgorithm(test);
        }

        static void FloidAlgorithm(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int[,] resMatrix = new int[n, n];

            // Инициализация результата
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        resMatrix[i, j] = 0;
                    }
                    else
                    {
                        resMatrix[i, j] = matrix[i, j];
                    }
                }
            }

            // Алгоритм Флойда
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (resMatrix[i, k] != int.MaxValue && resMatrix[k, j] != int.MaxValue && resMatrix[i, k] + resMatrix[k, j] < resMatrix[i, j])
                        {
                            resMatrix[i, j] = resMatrix[i, k] + resMatrix[k, j];
                        }
                    }
                }
            }

            // Вывод результата
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Из вершины {i}: ");
                for (int j = 0; j < n; j++)
                {
                    Console.Write(resMatrix[i, j] == int.MaxValue ? "INF " : resMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

