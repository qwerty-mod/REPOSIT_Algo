using System; 

class generalmain<T> // обобщённый класс
{
    private T[] stuffz; 
    private int howMany; 

    
    public generalmain(int sizey)
    {
        stuffz = new T[sizey]; 
        howMany = 0; 
    }

    // метод для добавления элемента в массив
    public void PutThing(T newThing)
    {
        if (howMany >= stuffz.Length) 
        {
            Console.WriteLine("Больше нет места для вещей"); 
            return; 
        }

        stuffz[howMany] = newThing; 
        howMany++; 
    }

    // метод для удаления элемента по индексу
    public void ThrowAway(int where)
    {
        if (where < 0 || where >= howMany) 
        {
            Console.WriteLine("Неправильный номер позиции");
            return; 
        }

        
        for (int i = where; i < howMany - 1; i++)
        {
            stuffz[i] = stuffz[i + 1]; 
        }

        howMany--; 
    }

    // метод для получения элемента по индексу
    public T GrabThing(int posishun)
    {
        if (posishun < 0 || posishun >= howMany) 
        {
            Console.WriteLine("Нельзя взять из этой позиции"); 
            return default(T);
        }

        return stuffz[posishun];
    }

    // вывод на экран
    public void ShowAll()
    {
        for (int i = 0; i < howMany; i++) 
        {
            Console.WriteLine("Вещь #" + i + ": " + stuffz[i]); 
        }
    }
}


class Start
{
    static void Main()
    {
        generalmain<string> myBoxy = new generalmain<string>(5); 

        myBoxy.PutThing("ручка");     // 
        myBoxy.PutThing("пенал");    // добавляем вещи
        myBoxy.PutThing("ластик");  // 

        myBoxy.ShowAll(); 

        Console.WriteLine("Взять из позиции 1: " + myBoxy.GrabThing(1)); 

        myBoxy.ThrowAway(0); // удаляем 

        myBoxy.ShowAll(); 
    }
}


