using Enums;

namespace ShapeParameters
{
    public class IntegerParameterValue : ShapeParameter<int>
    {
        public  int Value { get; set; }

        public IntegerParameterValue(EParameters type, int value) : base(type,value)
        {
            Value = value;
        }
    }
}