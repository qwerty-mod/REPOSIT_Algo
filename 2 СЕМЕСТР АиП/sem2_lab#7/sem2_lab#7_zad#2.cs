using System;
using System.Collections.Generic;

class Mashina
{
    public int god;
    public string model;
    public string cvet;
    public bool chistaya;

    public Mashina(int god, string model, string cvet, bool chistaya)
    {
        this.god = god;
        this.model = model;
        this.cvet = cvet;
        this.chistaya = chistaya;
    }

    public void Info()
    {
        Console.WriteLine($"{model} ({god}, {cvet}) - {(chistaya ? "Чистая" : "Грязная")}");
    }
}

class Garazh
{
    public List<Mashina> list_Car = new List<Mashina>();

    public void PomytMashiny(DelegatMoyka moyka)
    {
        foreach (var mashina in list_Car)
        {
            moyka(mashina);
        }
    }
}

class Moyka
{
    public void Pomyt(Mashina mashina)
    {
        if (!mashina.chistaya)
        {
            mashina.chistaya = true;
            Console.WriteLine($"{mashina.model} помыта.");
        }
        else
        {
            Console.WriteLine($"{mashina.model} уже чистая.");
        }
    }
}

delegate void DelegatMoyka(Mashina mashina);

class Program
{
    static void Main()
    {
        Mashina m1 = new Mashina(2010, "BMW", "Черный", false);
        Mashina m2 = new Mashina(2015, "Toyota", "Белый", true);

        Garazh garazh = new Garazh();
        garazh.list_Car.Add(m1);
        garazh.list_Car.Add(m2);

        Console.WriteLine("До мойки:");
        foreach (var mashina in garazh.list_Car)
        {
            mashina.Info();
        }

        Moyka moyka = new Moyka();
        DelegatMoyka delegat = moyka.Pomyt;

        Console.WriteLine("\nМоем машины:");
        garazh.PomytMashiny(delegat);

        Console.WriteLine("\nПосле мойки:");
        foreach (var mashina in garazh.list_Car)
        {
            mashina.Info();
        }
    }
}


