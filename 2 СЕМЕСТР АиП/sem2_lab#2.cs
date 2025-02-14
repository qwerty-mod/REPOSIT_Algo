using System; 

// Интерфейс с методами для расчёта периметра и площади
interface Izmerenie
{
    double Perimetr();
    double Ploshad();
}

// Базовый класс для всех фигур
class Figura
{
    public string imya; 

    public Figura(string nazvanie) 
    {
        imya = nazvanie;
    }
}

// Окружность
class Krug : Figura, Izmerenie
{
    public double radius; 

    public Krug(double r) : base("Круг") // Передаём название "Круг" в базовый класс
    {
        radius = r;
    }

    public double Perimetr() 
    {
        return 2 * 3.14 * radius;
    }

    public double Ploshad() 
    {
        return 3.14 * radius * radius;
    }
}

// Квадрат
class Kvadrat : Figura, Izmerenie
{
    public double storona; // Длина стороны квадрата

    public Kvadrat(double s) : base("Квадрат") // Передаём название "Квадрат" в базовый класс
    {
        storona = s;
    }

    public double Perimetr() 
    {
        return 4 * storona;
    }

    public double Ploshad() 
    {
        return storona * storona;
    }
}

// Равносторонний треугольник
class Treugolnik : Figura, Izmerenie
{
    public double storona; // Длина стороны треугольника

    public Treugolnik(double s) : base("Треугольник") // Передаём название "Треугольник" в базовый класс
    {
        storona = s;
    }

    public double Perimetr() 
    {
        return 3 * storona;
    }

    public double Ploshad() 
    {
        return (1.73 / 4) * storona * storona; // 1.73 ≈ √3
    }
}

// Главный класс программы
class Programma
{
    static void Main()
    {
        Krug krug = new Krug(5); 
        Kvadrat kvadrat = new Kvadrat(4); 
        Treugolnik treugolnik = new Treugolnik(6); 

        
        Console.WriteLine(krug.imya + ": Периметр = " + krug.Perimetr() + ", Площадь = " + krug.Ploshad());
        Console.WriteLine(kvadrat.imya + ": Периметр = " + kvadrat.Perimetr() + ", Площадь = " + kvadrat.Ploshad());
        Console.WriteLine(treugolnik.imya + ": Периметр = " + treugolnik.Perimetr() + ", Площадь = " + treugolnik.Ploshad());
    }
}

