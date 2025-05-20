using System;
using System.Collections.Generic;
using System.Linq;

class Link
{
    public int To;
    public int Cap;
    public int InitCap;

    public Link(int to, int cap)
    {
        To = to;
        Cap = cap;
        InitCap = cap;
    }
}

class Net
{
    private Dictionary<int, List<Link>> g;

    public Net()
    {
        g = new Dictionary<int, List<Link>>();
    }

    public void Conn(int a, int b, int cap)
    {
        if (!g.ContainsKey(a)) g[a] = new List<Link>();
        if (!g.ContainsKey(b)) g[b] = new List<Link>();

        g[a].Add(new Link(b, cap));
        g[b].Add(new Link(a, 0)); // откат
    }

    public int Pump(int start, int end)
    {
        int max = g.SelectMany(x => x.Value).Max(e => e.Cap);
        int bit = 1;
        while (bit * 2 <= max) bit *= 2;

        int result = 0;
        while (bit > 0)
        {
            while (true)
            {
                var seen = new HashSet<int>();
                var path = new List<int>();

                if (!Way(start, end, seen, path, bit))
                    break;

                int tight = path.Zip(path.Skip(1), (u, v) => g[u].First(e => e.To == v).Cap).Min();

                for (int i = 0; i < path.Count - 1; i++)
                {
                    int u = path[i], v = path[i + 1];
                    g[u].First(e => e.To == v).Cap -= tight;
                    g[v].First(e => e.To == u).Cap += tight;
                }

                result += tight;
            }

            bit /= 2;
        }

        return result;
    }

    private bool Way(int curr, int end, HashSet<int> seen, List<int> path, int bit)
    {
        seen.Add(curr);
        path.Add(curr);

        if (curr == end) return true;

        foreach (var e in g[curr])
        {
            if (e.Cap >= bit && !seen.Contains(e.To))
                if (Way(e.To, end, seen, path, bit))
                    return true;
        }

        path.RemoveAt(path.Count - 1);
        return false;
    }

    public void Out()
    {
        Console.WriteLine("------ Сводка Потоков ------");
        foreach (var kv in g)
        {
            int from = kv.Key;
            foreach (var e in kv.Value)
            {
                if (e.InitCap > 0)
                {
                    int used = e.InitCap - e.Cap;
                    Console.WriteLine($"[{from} → {e.To}] → {used} из {e.InitCap}");
                }
            }
        }
        Console.WriteLine("----------------------------");
    }
}

class Run
{
    static void Main()
    {
        var net = new Net();

        net.Conn(0, 1, 10);
        net.Conn(0, 2, 5);
        net.Conn(1, 2, 15);
        net.Conn(1, 3, 10);
        net.Conn(2, 3, 10);

        int flow = net.Pump(0, 3);
        Console.WriteLine($" Итоговый поток: {flow}");
        net.Out();
    }
}

