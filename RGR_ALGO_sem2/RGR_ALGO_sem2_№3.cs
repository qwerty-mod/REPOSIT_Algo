using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class P
{
    static Dictionary<string, Queue<string>> m = new Dictionary<string, Queue<string>>();
    static HashSet<string> u = new HashSet<string>();
    static List<int> l = new List<int>();

    static void Main()
    {
        var p = @"C:\Users\user\Desktop\input.txt";
        var c = File.ReadAllLines(p).Select(x => x.Trim()).Where(x => x.Length > 0).ToList();

        foreach (var t in c)
        {
            var k = t[0] + "_" + t[t.Length - 1];
            if (!m.ContainsKey(k)) m[k] = new Queue<string>();
            m[k].Enqueue(t);
        }

        while (u.Count < c.Count)
        {
            List<string> mc = null;

            foreach (var v in m)
            {
                foreach (var t in v.Value)
                {
                    if (u.Contains(t)) continue;

                    var s = new HashSet<string>();
                    var r = new List<string>();
                    List<string> f;

                    F(t, s, r, out f);

                    if (f != null && (mc == null || f.Count > mc.Count)) mc = f;
                    break;
                }
            }

            if (mc != null)
            {
                foreach (var t in mc) u.Add(t);
                l.Add(mc.Count);
            }
        }

        Console.WriteLine(l.Count);
        foreach (var x in l) Console.WriteLine(x);
    }

    static void F(string t, HashSet<string> s, List<string> r, out List<string> b)
    {
        r.Add(t);
        s.Add(t);
        b = null;

        char e = t[t.Length - 1];

        for (char d = 'a'; d <= 'z'; d++)
        {
            string k = e + "_" + d;
            if (!m.ContainsKey(k)) continue;

            foreach (var n in m[k])
            {
                if (u.Contains(n) || s.Contains(n)) continue;

                List<string> z;
                F(n, s, r, out z);

                if (z != null && (b == null || z.Count > b.Count)) b = new List<string>(z);
            }
        }

        if (r.Count >= 2 && r[0][0] == r[r.Count - 1][r[r.Count - 1].Length - 1])
        {
            if (b == null || r.Count > b.Count) b = new List<string>(r);
        }

        r.RemoveAt(r.Count - 1);
        s.Remove(t);
    }
}