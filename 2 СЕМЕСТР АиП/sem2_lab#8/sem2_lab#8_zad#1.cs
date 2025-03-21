using System;



class Tochka
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public Tochka(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Dvigat(int dx, int dy)
    {
        X += dx;
        Y += dy;
    }
}

class Pole 
{
    private int minX, maxX, minY, maxY;
    private Random randik = new Random();
    public Tochka Toch { get; private set; }

    public Pole(int minX, int maxX, int minY, int maxY, int startX, int startY)
    {
        this.minX = minX;
        this.maxX = maxX;
        this.minY = minY;
        this.maxY = maxY;
        Toch = new Tochka(startX, startY);
    }

    public void DvigatTochku()
    {
        Toch.Dvigat(randik.Next(-1, 2), randik.Next(-1, 2));
        Proverka_Granizi();
    }

    private void Proverka_Granizi()
    {
        if (Toch.X < minX || Toch.X > maxX || Toch.Y < minY || Toch.Y > maxY)
        {
            Console.WriteLine($"Точка за границей! ({Toch.X}, {Toch.Y})");
        }
        else
        {
            Console.WriteLine($"Точка в пределах поля ({Toch.X}, {Toch.Y})");
        }
    }
}

class Programma
{
    static void Main()
    {
        Pole pole = new Pole(0, 5, 0, 5, 2, 2);  // поле размером 5 на 5 ( квадрат где левый нижний угол {0;0}, а правый верхний {5,5})

        for (int i = 0; i < 20; i++)
        {
            pole.DvigatTochku();
            System.Threading.Thread.Sleep(500);
        }
    }
}


