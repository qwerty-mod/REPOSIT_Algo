using System;
using System.Collections.Generic;
using System.Linq;

class Postavshiki
{
    public int num_tov { get; set; }
    public string imya { get; set; }
    public string phone { get; set; }
}

class Tovar
{
    public int idTov { get; set; }
    public string nazva { get; set; }
}

class DvigTovara
{
    public int kodTov { get; set; }
    public int kodPostav { get; set; }
    public string tip_DVIG { get; set; } 
    public DateTime dataKogda { get; set; }
    public int skolko { get; set; }
    public decimal zaOdin { get; set; }
}

class Program
{
    static void Main()
    {
        var postavChik = new List<Postavshiki>()
        {
            new Postavshiki{ num_tov = 101, imya = "Поставщик А", phone = "8-999" },
            new Postavshiki{ num_tov = 102, imya = "Поставщик Б", phone = "8-888" }
        };

        var tovarList = new List<Tovar>()
        {
            new Tovar{ idTov = 1, nazva = "Товар 1" },
            new Tovar{ idTov = 2, nazva = "Товар 2" }
        };

        var tovarMoviks = new List<DvigTovara>()
        {
            new DvigTovara{ kodTov = 1, kodPostav = 101, tip_DVIG = "Поступление", dataKogda = DateTime.Parse("2024-01-01"), skolko = 99, zaOdin = 12 },
            new DvigTovara{ kodTov = 1, kodPostav = 101, tip_DVIG = "Продажа", dataKogda = DateTime.Parse("2024-02-10"), skolko = 33, zaOdin = 20 },
            new DvigTovara{ kodTov = 2, kodPostav = 102, tip_DVIG = "Поступление", dataKogda = DateTime.Parse("2024-01-20"), skolko = 55, zaOdin = 15 },
            new DvigTovara{ kodTov = 2, kodPostav = 102, tip_DVIG = "Продажа", dataKogda = DateTime.Parse("2024-03-01"), skolko = 10, zaOdin = 25 }
        };

        
        Console.WriteLine("=== ИТОГОВЫЕ ОСТАТКИ НА СКЛАДЕ ===");
        var ostatki = tovarMoviks
            .GroupBy(x => x.kodTov)
            .Select(grp => new
            {
                nazvishko = tovarList.First(t => t.idTov == grp.Key).nazva,
                ost = grp.Where(x => x.tip_DVIG == "Поступление").Sum(x => x.skolko)
                     - grp.Where(x => x.tip_DVIG == "Продажа").Sum(x => x.skolko)
            });

        foreach (var v in ostatki)
        {
            string status = v.ost > 0 ? "На складе осталось" : "Товара нет в наличии";
            Console.WriteLine($"{v.nazvishko}: {status} — {Math.Max(v.ost, 0)} шт.");
        }

        Console.WriteLine("\n=== ПОСТАВКИ ОТ КАЖДОГО ПОСТАВЩИКА ===");
        var groupoPostav = tovarMoviks
            .Where(p => p.tip_DVIG == "Поступление")
            .GroupBy(x => x.kodPostav)
            .Select(gr => new
            {
                kto = postavChik.First(z => z.num_tov == gr.Key).imya,
                chёPrivez = gr.Select(y => tovarList.First(t => t.idTov == y.kodTov).nazva).Distinct()
            });

        foreach (var g in groupoPostav)
        {
            Console.WriteLine($"От {g.kto} поступили следующие товары:");
            foreach (var tv in g.chёPrivez)
                Console.WriteLine($" - {tv}");
        }

        Console.WriteLine("\n=== ПРОДАЖИ ПО ДАТАМ ===");
        var prodajkaDayka = tovarMoviks
            .Where(x => x.tip_DVIG == "Продажа")
            .GroupBy(x => x.dataKogda.Date)
            .Select(bla => new
            {
                denek = bla.Key,
                prodali = bla.Select(x => tovarList.First(t => t.idTov == x.kodTov).nazva).Distinct()
            });

        foreach (var groupa in prodajkaDayka)
        {
            Console.WriteLine($"Дата: {groupa.denek.ToString("dd.MM.yyyy")}");
            Console.WriteLine("Проданы следующие товары:");
            foreach (var it in groupa.prodali)
                Console.WriteLine($" - {it}");
        }

        Console.ReadLine();
    }
}


