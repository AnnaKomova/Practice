namespace CW5.Variant00
{
    public interface IList
    {
        INumber[] Numbers { get; }
        string ID { get; }
        void Add(INumber number);
        void Add(INumber[] number);
        INumber[] GetPositive();
    }
}
