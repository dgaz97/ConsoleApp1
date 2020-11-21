using System;

//public delegate String dlgt(object num);
public class Number
{
    double[] numbers = new double[5];

    public double this[int i]
    {
        get => numbers[i];
        set => numbers[i] = value;
    }


    public Func<object,String> d = (object x) => $"{x} dobiven iz default delegate metode";
    //public dlgt d = (object x) => $"{x} dobiven iz default delegate metode";


    public String genericnaMetoda <T>(T num)
    {
        return $"Generirani string tipa {num.GetType().FullName}: {num}";
    }

    public String test<T>(T num)
    {
        return d(num);
    }

    public String deleTest<T>(T x, Func<T, String> operacija)
    {
        return operacija(x);
    }



}