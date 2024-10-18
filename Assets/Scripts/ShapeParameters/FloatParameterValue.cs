using Enums;

namespace ShapeParameters
{
    public class FloatParameterValue : ShapeParameter<float>
    {
        public float Value { get; set; }

        public FloatParameterValue(EParameters type, float value) : base(type,value)
        {
            Value = value;
        }
    }
}