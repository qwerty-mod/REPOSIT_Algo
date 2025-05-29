using System;
using System.Collections.Generic;

class Potok
{
    private int V; 

    public Potok(int size)
    {
        V = size;
    }

    
    public int OSN_metod(int[,] graph, int start, int end)
    {
        int[,] ostat_set = new int[V, V];
        Array.Copy(graph, ostat_set, graph.Length);

        int[] vostanovlenie_puti_ot_stoka_k_istoku = new int[V];
        int sum_maxPOTOKOV = 0;

        while (GO(ostat_set, start, end, vostanovlenie_puti_ot_stoka_k_istoku))
        {
            int min_propusk_SPOSOBnost = int.MaxValue;

            // мин поток
            for (int v = end; v != start; v = vostanovlenie_puti_ot_stoka_k_istoku[v])
            {
                int u = vostanovlenie_puti_ot_stoka_k_istoku[v];
                min_propusk_SPOSOBnost = Math.Min(min_propusk_SPOSOBnost, ostat_set[u, v]);
            }

            // обнова остатков
            for (int v = end; v != start; v = vostanovlenie_puti_ot_stoka_k_istoku[v])
            {
                int u = vostanovlenie_puti_ot_stoka_k_istoku[v];
                ostat_set[u, v] -= min_propusk_SPOSOBnost;
                ostat_set[v, u] += min_propusk_SPOSOBnost;
            }

            sum_maxPOTOKOV += min_propusk_SPOSOBnost;
        }

        return sum_maxPOTOKOV;
    }

    
    private bool GO(int[,] graph, int s, int t, int[] p)
    {
        bool[] visit = new bool[V];
        Queue<int> q = new Queue<int>();
        q.Enqueue(s);
        visit[s] = true;
        p[s] = -1;

        while (q.Count > 0)
        {
            int u = q.Dequeue();

            for (int v = 0; v < V; v++)
            {
                if (!visit[v] && graph[u, v] > 0)
                {
                    q.Enqueue(v);
                    p[v] = u;
                    visit[v] = true;
                }
            }
        }

        return visit[t];
    }
}

class Algoritm_FORD_FALKERSON
{
    static void Main()
    {
        
        int[,] net = {
            {0, 16, 13, 0, 0, 0},
            {0, 0, 10, 12, 0, 0},
            {0, 4, 0, 0, 14, 0},
            {0, 0, 9, 0, 0, 20},
            {0, 0, 0, 7, 0, 4},
            {0, 0, 0, 0, 0, 0}
        };

        Potok result = new Potok(6);
        int source = 0;
        int sink = 5;
        int maxFlow = result.OSN_metod(net, source, sink);

        Console.WriteLine("Максимальный поток равен: " + maxFlow);
    }
}
