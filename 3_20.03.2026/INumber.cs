namespace CW5.Variant00
{
    public interface INumber
    {
        double Real { get; }
        double Abs { get; }
        int Sign { get; }
        void Sum(INumber other);
        void Sub(INumber other);
        void Mul(INumber other);
        void Div(INumber other);
        void Neg();
    }
}
