using System;

class SquaredArray
{
    private double[] data; // Одномерный массив данных

    public SquaredArray(int size)
    {
        data = new double[size];
    }

    // Индексатор для массива
    public double this[int index]
    {
        get
        {
            return data[index];
        }
        set
        {
            data[index] = value * value; // Возводим значение в квадрат перед сохранением
        }
    }
}

class Program
{
    static void Main()
    {
        int size = 5;
        SquaredArray arr = new SquaredArray(size);

        // Установка значений с автоматическим возведением в квадрат
        arr[0] = 2;
        arr[1] = 3;
        arr[2] = 4;
        arr[3] = 5;
        arr[4] = 6;

        // Получение и вывод элементов массива
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"arr[{i}] = {arr[i]}");
        }
    }
}
