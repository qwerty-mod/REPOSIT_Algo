using System;
using System.Collections.Generic;
using System.Linq;

class EdgeData
{
    public int Target { get; set; }
    public int Capacity { get; set; }

    public EdgeData(int target, int capacity)
    {
        Target = target;
        Capacity = capacity;
    }
}

class PathStep
{
    public int From { get; private set; }
    public int To { get; private set; }
    public int Capacity { get; private set; }

    public PathStep(int from, int to, int capacity)
    {
        From = from;
        To = to;
        Capacity = capacity;
    }
}

class FlowNetwork
{
    private Dictionary<int, List<EdgeData>> adjacency;
    private Dictionary<Tuple<int, int>, int> usedFlow;

    public FlowNetwork()
    {
        adjacency = new Dictionary<int, List<EdgeData>>();
        usedFlow = new Dictionary<Tuple<int, int>, int>();
    }

    public void Connect(int from, int to, int capacity)
    {
        if (!adjacency.ContainsKey(from))
        {
            adjacency[from] = new List<EdgeData>();
        }
        adjacency[from].Add(new EdgeData(to, capacity));
    }

    public int ExecuteFlow(int source, int sink)
    {
        int totalFlow = 0;

        while (true)
        {
            List<PathStep> path = TracePath(source, sink, new HashSet<int>());
            if (path.Count == 0)
                break;

            int minFlow = int.MaxValue;
            foreach (var step in path)
            {
                if (step.Capacity < minFlow)
                    minFlow = step.Capacity;
            }

            foreach (var step in path)
            {
                List<EdgeData> edgeList = adjacency[step.From];
                EdgeData edge = edgeList.FirstOrDefault(e => e.Target == step.To);
                if (edge != null)
                {
                    edge.Capacity -= minFlow;
                }

                var key = Tuple.Create(step.From, step.To);
                if (!usedFlow.ContainsKey(key))
                    usedFlow[key] = 0;
                usedFlow[key] += minFlow;
            }

            totalFlow += minFlow;
        }

        return totalFlow;
    }

    public void ShowFlows()
    {
        Console.WriteLine("Результаты по дугам:");
        foreach (var entry in usedFlow)
        {
            int from = entry.Key.Item1;
            int to = entry.Key.Item2;
            int passed = entry.Value;

            int remaining = 0;
            if (adjacency.ContainsKey(from))
            {
                var found = adjacency[from].FirstOrDefault(e => e.Target == to);
                if (found != null)
                    remaining = found.Capacity;
            }

            Console.WriteLine($"{from} -> {to}: {passed}/{passed + remaining}");
        }
    }

    private List<PathStep> TracePath(int current, int target, HashSet<int> visited)
    {
        if (current == target)
            return new List<PathStep>();

        visited.Add(current);

        if (!adjacency.ContainsKey(current))
            return new List<PathStep>();

        var sortedEdges = adjacency[current]
            .Where(e => e.Capacity > 0 && !visited.Contains(e.Target))
            .OrderByDescending(e => e.Capacity)
            .ToList();

        foreach (var edge in sortedEdges)
        {
            List<PathStep> result = TracePath(edge.Target, target, visited);
            if (result != null)
            {
                result.Insert(0, new PathStep(current, edge.Target, edge.Capacity));
                return result;
            }
        }

        return new List<PathStep>();
    }
}

class FORD_FALKERSON
{
    static void Main()
    {
        FlowNetwork network = new FlowNetwork();

        network.Connect(0, 1, 10);
        network.Connect(0, 2, 5);
        network.Connect(1, 2, 15);
        network.Connect(1, 3, 10);
        network.Connect(2, 3, 10);

        int maxFlow = network.ExecuteFlow(0, 3);
        Console.WriteLine("Общий поток: " + maxFlow);
        network.ShowFlows();
    }
}

