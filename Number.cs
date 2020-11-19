using System;

public delegate String dlgt(object num);
public class Number
{
    double[] numbers = new double[5];

    public double this[int i]
    {
        get => numbers[i];
        set => numbers[i] = value;
    }


    public dlgt d = new dlgt((x) => $"{x} dobiven iz default delegate metode");


    public String genericnaMetoda <T>(T num)
    {
        return $"Generirani string tipa {num.GetType().FullName}: {num}";
    }

    public String test<T>(T num)
    {
        return d(num);
    }



}