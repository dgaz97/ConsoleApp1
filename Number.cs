public class Number
{
    double[] numbers = new double[5];

    public double this[int i]
    {
        get => numbers[i];
        set => numbers[i] = value;
    }
}