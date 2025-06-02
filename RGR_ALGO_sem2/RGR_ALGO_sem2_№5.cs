using System;
using System.IO;
using System.Linq;

class PolygonAreaCalculator
{
    struct Point { public int X, Y; public Point(int x, int y) { X = x; Y = y; } }

    static void Main()
    {
        var lines = File.ReadAllLines(@"C:\Users\user\Desktop\input.txt");
        int pointCount = int.Parse(lines[0]);
        var points = new Point[pointCount];

        for (int i = 0; i < pointCount; i++)
        {
            var coords = lines[i + 1].Split(' ');
            points[i] = new Point(int.Parse(coords[0]), int.Parse(coords[1]));
        }

        var convexHull = BuildConvexHull(points);
        double area = CalculatePolygonArea(convexHull);
        Console.WriteLine(area.ToString("F3"));
    }

    static Point[] BuildConvexHull(Point[] points)
    {
        if (points.Length <= 3) return points;

        var sortedPoints = points.OrderBy(p => p.X).ThenBy(p => p.Y).ToArray();

        Point[] upperHull = new Point[points.Length];
        upperHull[0] = sortedPoints[0];
        upperHull[1] = sortedPoints[1];
        int upperCount = 2;

        for (int i = 2; i < sortedPoints.Length; i++)
        {
            while (upperCount >= 2 && CrossProduct(upperHull[upperCount - 2], upperHull[upperCount - 1], sortedPoints[i]) >= 0)
                upperCount--;
            upperHull[upperCount++] = sortedPoints[i];
        }

        Point[] lowerHull = new Point[points.Length];
        lowerHull[0] = sortedPoints[sortedPoints.Length - 1];
        lowerHull[1] = sortedPoints[sortedPoints.Length - 2];
        int lowerCount = 2;

        for (int i = sortedPoints.Length - 3; i >= 0; i--)
        {
            while (lowerCount >= 2 && CrossProduct(lowerHull[lowerCount - 2], lowerHull[lowerCount - 1], sortedPoints[i]) >= 0)
                lowerCount--;
            lowerHull[lowerCount++] = sortedPoints[i];
        }

        var result = new Point[upperCount + lowerCount - 2];
        Array.Copy(upperHull, 0, result, 0, upperCount);
        Array.Copy(lowerHull, 1, result, upperCount, lowerCount - 2);

        return result;
    }

    static double CalculatePolygonArea(Point[] polygon)
    {
        double sum = 0;
        int n = polygon.Length;

        for (int i = 0; i < n; i++)
        {
            var current = polygon[i];
            var next = polygon[(i + 1) % n];
            sum += (current.X * next.Y) - (next.X * current.Y);
        }

        return Math.Abs(sum) / 2;
    }

    static long CrossProduct(Point a, Point b, Point c)
    {
        return (long)(b.X - a.X) * (c.Y - a.Y) - (long)(b.Y - a.Y) * (c.X - a.X);
    }
}