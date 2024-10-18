using Enums;

namespace ShapeParameters
{
    public  abstract class ShapeParameter<T> : IShapeParameter<T> where T : struct
    {
        protected ShapeParameter(EParameters type, T value)
        {
            Type = type;
            Value = value;
        }

        public EParameters Type { get; }
        public T Value { get; set; }
    }
}