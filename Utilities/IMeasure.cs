namespace Utilities
{
    public interface IMeasure
    {
        string Name { get; }
        float Value { get; }
        float Print();
    }
}
