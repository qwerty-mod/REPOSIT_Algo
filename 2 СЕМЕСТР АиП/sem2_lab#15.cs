using System;
using System.Collections.Generic;
using System.Linq;

class MarkaModeli
{
    public int Num { get; set; }
    public string marka { get; set; }
    public string model { get; set; }
}

class OS
{
    public int Num { get; set; }
    public string imyaOS { get; set; }
}

class Peoples
{
    public int id_P { get; set; }
    public string FIO { get; set; }
    public string nalichie { get; set; } 
    public int? markanout_ID { get; set; }
    public int? ID_OS { get; set; }
}

class Program
{
    static void Main()
    {
        var markoModels = new List<MarkaModeli>
        {
            new MarkaModeli{ Num = 1, marka = "ASUS", model = "Vivobook" },
            new MarkaModeli{ Num = 2, marka = "HP", model = "Pavilion" },
            new MarkaModeli{ Num = 3, marka = "Lenovo", model = "ThinkPad" }
        };

        var OSki = new List<OS>
        {
            new OS{ Num = 1, imyaOS = "Windows 10" },
            new OS{ Num = 2, imyaOS = "Linux Mint" },
            new OS{ Num = 3, imyaOS = "macOS Ventura" }
        };

        var polzovateli = new List<Peoples>
        {
            new Peoples{ id_P = 101, FIO = "Сидоров А.Л.", nalichie = "Да", markanout_ID = 1, ID_OS = 1 },
            new Peoples{ id_P = 102, FIO = "Иванова Т.С.", nalichie = "Нет", markanout_ID = null, ID_OS = null },
            new Peoples{ id_P = 103, FIO = "Карпов Н.К.", nalichie = "Да", markanout_ID = 2, ID_OS = 2 },
            new Peoples{ id_P = 104, FIO = "Лебедев Ю.В.", nalichie = "Да", markanout_ID = 3, ID_OS = 1 }
        };

        
        Console.WriteLine("Пользователи по наличию ноутбука:");
        var groupNout = polzovateli
            .GroupBy(p => p.nalichie)
            .Select(g => new { estik = g.Key, kto = g.Select(z => z.FIO) });

        foreach (var gr in groupNout)
        {
            Console.WriteLine($"Наличие: {gr.estik}");
            foreach (var pers in gr.kto)
                Console.WriteLine($" - {pers}");
        }

        Console.WriteLine();

        
        Console.WriteLine("Пользователи по марке ноутбука:");
        var groupMarca = polzovateli
            .Where(p => p.markanout_ID.HasValue)
            .GroupBy(p => p.markanout_ID.Value)
            .Select(g => new
            {
                marka = markoModels.First(m => m.Num == g.Key).marka,
                ludi = g.Select(x => x.FIO)
            });

        foreach (var mark in groupMarca)
        {
            Console.WriteLine($"Марка: {mark.marka}");
            foreach (var pers in mark.ludi)
                Console.WriteLine($" - {pers}");
        }

        Console.WriteLine();

        
        Console.WriteLine("Пользователи по операционной системе:");
        var groupOS = polzovateli
            .Where(p => p.ID_OS.HasValue)
            .GroupBy(p => p.ID_OS.Value)
            .Select(g => new
            {
                osik = OSki.First(o => o.Num == g.Key).imyaOS,
                polziki = g.Select(x => x.FIO)
            });

        foreach (var os in groupOS)
        {
            Console.WriteLine($"ОС: {os.osik}");
            foreach (var perzon in os.polziki)
                Console.WriteLine($" - {perzon}");
        }

        Console.WriteLine();

        
        Console.WriteLine("Полные данные о пользователях:");
        var fullinfo = polzovateli.Select(p => new
        {
            chelovek = p.FIO,
            estNout = p.nalichie,
            marka = p.markanout_ID.HasValue ? markoModels.First(m => m.Num == p.markanout_ID).marka : "—",
            model = p.markanout_ID.HasValue ? markoModels.First(m => m.Num == p.markanout_ID).model : "—",
            OSka = p.ID_OS.HasValue ? OSki.First(o => o.Num == p.ID_OS).imyaOS : "—"
        });

        foreach (var inf in fullinfo)
        {
            Console.WriteLine($"Пользователь: {inf.chelovek} | Ноутбук: {inf.estNout} | Марка: {inf.marka} | Модель: {inf.model} | ОС: {inf.OSka}");
        }

        Console.ReadLine();
    }
}

