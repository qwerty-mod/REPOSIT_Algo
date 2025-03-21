using System;

class Loshad
{
    public string Imya { get; }
    public int X { get; private set; }
    private Random rand;
    private int minSpeed;
    private int maxSpeed;

    public Loshad(string imya, int minSkorost, int maxSkorost)
    {
        Imya = imya;
        X = 0;
        rand = new Random();
        this.minSpeed = minSkorost;
        this.maxSpeed = maxSkorost;
    }

    public void Begi()
    {
        X += rand.Next(minSpeed, maxSpeed + 1); // Разный диапазон скоростей для каждой лошади
    }
}

class Gonka
{
    private Loshad[] loshadi;
    private int finish;
    private Random rand = new Random();

    public Gonka(string[] imena, int finish)
    {
        this.finish = finish;
        loshadi = new Loshad[imena.Length];
        for (int i = 0; i < imena.Length; i++)
        {
            int minSkorost = rand.Next(1, 4);
            int maxSkorost = rand.Next(minSkorost + 1, 7);
            loshadi[i] = new Loshad(imena[i], minSkorost, maxSkorost);
        }
    }

    public void Start()
    {
        bool estPobeditel = false;
        while (!estPobeditel)
        {
            foreach (var loshad in loshadi)
            {
                loshad.Begi();
                Console.WriteLine($"{loshad.Imya} begit: {loshad.X}");

                if (loshad.X >= finish)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{loshad.Imya} победила!");
                    Console.WriteLine();
                    estPobeditel = true;
                    break;
                }
            }
            System.Threading.Thread.Sleep(500);
        }
    }
}

class Programma
{
    static void Main()
    {
        string[] imena = { "Бурка", "Маквин", "Усейн Болт" };
        Gonka gonka = new Gonka(imena, 20);
        gonka.Start();
    }
}





