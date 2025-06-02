using System;
using System.Collections.Generic;
using System.IO;

class X
{
    static int[,] G;
    static Queue<string[]> Q = new Queue<string[]>();

    static void Main()
    {
        var L = File.ReadAllLines(@"C:\Users\user\Desktop\input.txt");
        var D = L[0].Split();
        int W = int.Parse(D[0]), H = int.Parse(D[1]);
        G = new int[H, W];

        P(L[1], 0, 0, W, H, L);

        for (int y = 0; y < H; y++)
        {
            for (int x = 0; x < W; x++)
            {
                Console.Write(G[y, x] + (x < W - 1 ? " " : ""));
            }
            Console.WriteLine();
        }
    }

    static void P(string s, int x, int y, int w, int h, string[] L)
    {
        if (s == "Z")
        {
            Q.Enqueue(new string[] { x.ToString(), y.ToString(), w.ToString(), h.ToString() });
            R(L);
        }
        else
        {
            F(x, y, w, h, int.Parse(s));
        }
    }

    static void R(string[] L)
    {
        int i = 2;

        while (Q.Count > 0)
        {
            var c = Q.Dequeue();
            int x = int.Parse(c[0]), y = int.Parse(c[1]), w = int.Parse(c[2]), h = int.Parse(c[3]);

            if (i >= L.Length) continue;

            var p = L[i++].Split();
            T(p[0], x, y, w / 2 + w % 2, h / 2 + h % 2, L);
            T(p[1], x + w / 2 + w % 2, y, w / 2, h / 2 + h % 2, L);
            T(p[2], x, y + h / 2 + h % 2, w / 2 + w % 2, h / 2, L);
            T(p[3], x + w / 2 + w % 2, y + h / 2 + h % 2, w / 2, h / 2, L);
        }
    }

    static void T(string p, int x, int y, int w, int h, string[] L)
    {
        if (p == "-") return;

        if (p == "Z")
        {
            Q.Enqueue(new string[] { x.ToString(), y.ToString(), w.ToString(), h.ToString() });
        }
        else
        {
            F(x, y, w, h, int.Parse(p));
        }
    }

    static void F(int x, int y, int w, int h, int c)
    {
        for (int i = y; i < y + h; i++)
        {
            for (int j = x; j < x + w; j++)
            {
                G[i, j] = c;
            }
        }
    }
}
