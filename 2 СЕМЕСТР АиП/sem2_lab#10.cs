using System;
using System.Collections.Generic;

// Структура о выдаче книги
struct Vidacha
{
    public string dataVidachi;
    public string dataVozvrata; // если пусто — не возвращена

    public Vidacha(string dataVidachi, string dataVozvrata)
    {
        this.dataVidachi = dataVidachi;
        this.dataVozvrata = dataVozvrata;
    }
}

// Структура книги
struct Kniga
{
    public string familiyaAvtora;
    public string nazvanie;
    public int god;
    public string izdatelstvo;
    public List<Vidacha> istorii;

    public Kniga(string familiyaAvtora, string nazvanie, int god, string izdatelstvo)
    {
        this.familiyaAvtora = familiyaAvtora;
        this.nazvanie = nazvanie;
        this.god = god;
        this.izdatelstvo = izdatelstvo;
        this.istorii = new List<Vidacha>();
    }

    public void Pechat()
    {
        Console.WriteLine("Автор: " + familiyaAvtora);
        Console.WriteLine("Название: " + nazvanie);
        Console.WriteLine("Год: " + god);
        Console.WriteLine("Издательство: " + izdatelstvo);
        Console.WriteLine();
    }
}

class Programma
{
    static void Main()
    {
        
        List<Kniga> biblioteka = new List<Kniga>();

        // Книга 1 — была выдана, но не возвращена
        Kniga kniga1 = new Kniga("Толстой", "Война и мир", 1869, "РусЛит");
        kniga1.istorii.Add(new Vidacha("2024-01-10", "2024-01-20"));
        kniga1.istorii.Add(new Vidacha("2024-02-15", "")); // не возвращена
        biblioteka.Add(kniga1);

        // Книга 2 — никогда не выдавалась
        Kniga kniga2 = new Kniga("Достоевский", "Преступление и наказание", 1866, "ЛитМир");
        biblioteka.Add(kniga2);

        // Книга 3 — была выдана и возвращена
        Kniga kniga3 = new Kniga("Булгаков", "Мастер и Маргарита", 1967, "Советский писатель точка ком");
        kniga3.istorii.Add(new Vidacha("2023-10-05", "2023-10-15"));
        biblioteka.Add(kniga3);

        // Книги, которые ни разу не выдавались
        Console.WriteLine("Книги, которые ни разу не выдавались:\n");
        for (int i = 0; i < biblioteka.Count; i++)
        {
            if (biblioteka[i].istorii.Count == 0)
            {
                biblioteka[i].Pechat();
            }
        }

        // Книги, которые не были возвращены
        Console.WriteLine("Книги, которые не были возвращены:\n");
        for (int i = 0; i < biblioteka.Count; i++)
        {
            for (int j = 0; j < biblioteka[i].istorii.Count; j++)
            {
                if (biblioteka[i].istorii[j].dataVozvrata == "")
                {
                    biblioteka[i].Pechat();
                    break;
                }
            }
        }

        Console.ReadLine();
    }
}


