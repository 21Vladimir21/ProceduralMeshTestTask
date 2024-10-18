namespace ShapeParameters
{
    public interface IShapeParameter<T> : IParameter
    {
        T Value { get; }
    }
}