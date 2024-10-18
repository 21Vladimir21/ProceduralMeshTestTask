using System.Collections.Generic;
using Enums;
using Figures;
using ShapeParameters;
using UnityEngine;

namespace Shapes
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class Cube : ShapeBase
    {
        [field: SerializeField] public Vector3 Size { get; private set; } = new Vector3(1, 1, 1);

        public override List<IParameter> Parameters
        {
            get
            {
                var list = new List<IParameter>()
                {
                    new FloatParameterValue(EParameters.Wight, Size.x),
                    new FloatParameterValue(EParameters.Height, Size.y),
                    new FloatParameterValue(EParameters.Length, Size.z)
                };
                return list;
            }
        }

        private void Start() => Generate();

        public override void ChangeSize(List<IParameter> parameters)
        {
            var x = GetValue<float>(EParameters.Wight, parameters);
            var y = GetValue<float>(EParameters.Height, parameters);
            var z = GetValue<float>(EParameters.Length, parameters);
            Size = new Vector3(x, y, z);
            base.ChangeSize(parameters);
        }

        protected override int[] CreateTriangles()
        {
            int[] triangles =
            {
                0, 2, 1, 0, 3, 2,
                4, 5, 6, 4, 6, 7,
                0, 1, 5, 0, 5, 4,
                1, 2, 6, 1, 6, 5,
                2, 3, 7, 2, 7, 6,
                3, 0, 4, 3, 4, 7
            };
            return triangles;
        }

        protected override Vector3[] CreateVertices()
        {
            var offsetSize = Size * 0.5f;
            Vector3[] vertices =
            {
                new(-offsetSize.x, -offsetSize.y, -offsetSize.z),
                new(offsetSize.x, -offsetSize.y, -offsetSize.z),
                new(offsetSize.x, offsetSize.y, -offsetSize.z),
                new(-offsetSize.x, offsetSize.y, -offsetSize.z),
                new(-offsetSize.x, -offsetSize.y, offsetSize.z),
                new(offsetSize.x, -offsetSize.y, offsetSize.z),
                new(offsetSize.x, offsetSize.y, offsetSize.z),
                new(-offsetSize.x, offsetSize.y, offsetSize.z)
            };
            return vertices;
        }
    }
}