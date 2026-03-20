namespace CW5.Variant00
{
    public interface IComplexNumber : INumber
    {
        double Imaginary { get; }
        int ISign { get; }
    }
}
