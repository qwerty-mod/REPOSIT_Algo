using System;

class Chisla
{
    public int perv;
    public int vtor;

    public Chisla(int a, int b)
    {
        perv = a;
        vtor = b;
    }

    public int Slozhenie() => perv + vtor;
    public int Raznost() => perv - vtor;
    public int Umnozhenie() => perv * vtor;
    public int Delenie() => vtor != 0 ? perv / vtor : 0;
}

delegate int Operatsii();

class Program
{
    static void Main()
    {
        Console.WriteLine("Впишите два целых числа для ПЕРВОГО обьекта через Enter: ");
        int u = int.Parse(Console.ReadLine());
        int v = int.Parse(Console.ReadLine());

        Console.WriteLine("Впишите два целых числа для ВТОРОГО обьекта через Enter: ");
        int c = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());

        Chisla obj1 = new Chisla(u, v);
        Chisla obj2 = new Chisla(c, d);

        Operatsii del1 = () => obj1.Slozhenie();
        del1 += () => obj1.Slozhenie() * obj1.vtor;
        del1 += () => obj1.vtor != 0 ? (obj1.Slozhenie() * obj1.vtor) / obj1.vtor : 0;

        Operatsii del2 = () => obj2.Delenie();
        del2 += () => obj2.Delenie() - obj2.vtor;
        del2 += () => (obj2.Delenie() - obj2.vtor) * obj2.vtor;

        Console.WriteLine("Результат 1: " + del1.Invoke());
        Console.WriteLine("Результат 2: " + del2.Invoke());
    }
}

