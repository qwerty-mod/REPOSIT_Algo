using System;
using System.Collections.Generic;

namespace RouteOptimizer
{
    public class PathFinder
    {
        private readonly int[,] _cityDistances;
        private readonly int _totalCities;
        private int _optimalRouteCost = int.MaxValue;
        private List<int> _optimalPath = new List<int>();

        public PathFinder(int[,] distanceMatrix)
        {
            _cityDistances = distanceMatrix;
            _totalCities = distanceMatrix.GetLength(0);
        }

        public (int TotalCost, List<int> Route) FindBestRoute()
        {
            var unvisitedCities = new List<int>();
            for (int i = 1; i < _totalCities; i++)
                unvisitedCities.Add(i);

            ExploreRoutes(0, 0, unvisitedCities, new List<int>());

            _optimalPath.Add(0); 
            return (_optimalRouteCost, _optimalPath);
        }

        private void ExploreRoutes(int currentCity, int accumulatedCost,
                                 List<int> remainingCities, List<int> currentRoute)
        {
            currentRoute.Add(currentCity);

            if (remainingCities.Count == 0)
            {
                int returnCost = _cityDistances[currentCity, 0];
                if (returnCost != int.MaxValue)
                {
                    int total = accumulatedCost + returnCost;
                    if (total < _optimalRouteCost)
                    {
                        _optimalRouteCost = total;
                        _optimalPath = new List<int>(currentRoute);
                    }
                }
                currentRoute.RemoveAt(currentRoute.Count - 1);
                return;
            }

            int estimatedMinCost = EstimateMinimumCost(currentCity, remainingCities, accumulatedCost);
            if (estimatedMinCost >= _optimalRouteCost)
            {
                currentRoute.RemoveAt(currentRoute.Count - 1);
                return;
            }

            foreach (int nextCity in remainingCities)
            {
                int travelCost = _cityDistances[currentCity, nextCity];
                if (travelCost == int.MaxValue) continue;

                var newRemaining = new List<int>(remainingCities);
                newRemaining.Remove(nextCity);

                ExploreRoutes(nextCity, accumulatedCost + travelCost,
                            newRemaining, currentRoute);
            }

            currentRoute.RemoveAt(currentRoute.Count - 1);
        }

        private int EstimateMinimumCost(int fromCity, List<int> toCities, int baseCost)
        {
            int minExitCost = int.MaxValue;
            foreach (int city in toCities)
            {
                if (_cityDistances[fromCity, city] < minExitCost)
                    minExitCost = _cityDistances[fromCity, city];
            }
            if (minExitCost == int.MaxValue) return int.MaxValue;

            int sumEntryCosts = 0;
            foreach (int city in toCities)
            {
                int minEntryCost = int.MaxValue;
                for (int i = 0; i < _totalCities; i++)
                {
                    if (i == fromCity && toCities.Contains(city))
                        continue;

                    if (_cityDistances[i, city] < minEntryCost)
                        minEntryCost = _cityDistances[i, city];
                }
                if (minEntryCost == int.MaxValue) return int.MaxValue;
                sumEntryCosts += minEntryCost;
            }

            return baseCost + minExitCost + sumEntryCosts;
        }
    }

    public class AlgoritmLITTLA
    {
        public static void Main()
        {
            int[,] distances = new int[,]
            {
                { int.MaxValue, 12, 18, 24 },
                { 12, int.MaxValue, 36, 28 },
                { 18, 36, int.MaxValue, 32 },
                { 24, 28, 32, int.MaxValue }
            };

            var routeFinder = new PathFinder(distances);
            var solution = routeFinder.FindBestRoute();

            Console.WriteLine($"Наименьшая стоимость маршрута: {solution.TotalCost}");
            Console.WriteLine($"Оптимальный путь: {string.Join(" --> ", solution.Route)}");
        }
    }
}
