using System.Collections.Generic;
using Enums;
using ShapeParameters;
using UnityEngine;

namespace Shapes
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class Capsule : Sphere
    {
        [field: SerializeField] public float Height { get; private set; }

        public override List<IParameter> Parameters
        {
            get
            {
                var list = new List<IParameter>()
                {
                    new IntegerParameterValue(EParameters.Smoothness, Smoothness),
                    new FloatParameterValue(EParameters.Radius, Radius),
                    new FloatParameterValue(EParameters.Height, Height)
                };
                return list;
            }
        }

        private void Start() => Generate();

        public override void ChangeSize(List<IParameter> parameters)
        {
            Vertices.Clear();
            Smoothness = GetValue<int>(EParameters.Smoothness, parameters);
            Radius = GetValue<float>(EParameters.Radius, parameters);
            Height = GetValue<float>(EParameters.Height, parameters);
            base.ChangeSize(parameters);
        }


        protected override Vector3[] CreateVertices()
        {
            // Создание вершин вехней половины 
            var heightHalf = Height * 0.5f;
            for (int width = 1; width <= Smoothness * 0.5f; width++)
            {
                float theta = width * Mathf.PI / Smoothness; // Определение угла вершины по высоте 
                for (int lon = 0; lon < Smoothness; lon++)
                {
                    float phi = lon * 2 * Mathf.PI / Smoothness; // Определение угла вершины по широте
                    float x = Radius * Mathf.Sin(theta) * Mathf.Cos(phi);
                    float y = Radius * Mathf.Cos(theta); // Опредение высоты точки с учетом радиуса
                    float z = Radius * Mathf.Sin(theta) * Mathf.Sin(phi);

                    Vertices.Add(new Vector3(x, y + heightHalf, z));
                }
            }

            // Создание вершин нижней половины 
            var startLongIndex = (int)(Smoothness * 0.5f);
            for (int width = startLongIndex; width < Smoothness; width++)
            {
                float theta = width * Mathf.PI / Smoothness;
                for (int lon = 0; lon < Smoothness; lon++)
                {
                    float phi = lon * 2 * Mathf.PI / Smoothness;
                    float x = Radius * Mathf.Sin(theta) * Mathf.Cos(phi);
                    float y = Radius * Mathf.Cos(theta);
                    float z = Radius * Mathf.Sin(theta) * Mathf.Sin(phi);

                    Vertices.Add(new Vector3(x, y - heightHalf, z));
                }
            }

            Vertices.Add(new Vector3(0, Radius + heightHalf, 0));
            Vertices.Add(new Vector3(0, -Radius - heightHalf, 0));

            return Vertices.ToArray();
        }
        // Просчет треугольников происходит так же как и сфере, поэтому капсула наследуется от неё
    }
}