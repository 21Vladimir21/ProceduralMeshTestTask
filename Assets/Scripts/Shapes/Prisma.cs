using System.Collections.Generic;
using System.Drawing;
using Enums;
using Figures;
using ShapeParameters;
using UnityEngine;

namespace Shapes
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class Prisma : ShapeBase
    {
        [field: Space] [field: SerializeField] public float Height { get; private set; }
        [field: SerializeField] public float Radius { get; private set; }

        private readonly List<Vector3> _vertices = new();

        private const int BaseLayerCount = 2;
        private const int EdgeCount = 6;

        public override List<IParameter> Parameters
        {
            get
            {
                var list = new List<IParameter>()
                {
                    new FloatParameterValue(EParameters.Height, Height),
                    new FloatParameterValue(EParameters.Radius, Radius)
                };
                return list;
            }
        }


        public override void ChangeSize(List<IParameter> parameters)
        {
            _vertices.Clear();
            Radius = GetValue<float>(EParameters.Radius, parameters);
            Height = GetValue<float>(EParameters.Height, parameters);
            base.ChangeSize(parameters);
        }

        private void Start() => Generate();

        protected override Vector3[] CreateVertices()
        {
            // Создание вершин верхней и нижней части сферы
            var heightHalf = Height * 0.5f;
            for (int i = 0; i < BaseLayerCount; i++)
            {
                for (int lon = 0; lon < EdgeCount; lon++)
                {
                    float phi = lon * 2 * Mathf.PI / EdgeCount;
                    float x = Radius * Mathf.Cos(phi);
                    float z = Radius * Mathf.Sin(phi);

                    _vertices.Add(new Vector3(x, i > 0 ? -heightHalf : heightHalf, z));
                }
            }

            return _vertices.ToArray();
        }

        protected override int[] CreateTriangles()
        {
            var triangles = new List<int>();
            triangles.AddRange(FillTriangles());
            triangles.AddRange(FillSideTriangles());
            return triangles.ToArray();
        }

        private List<int> FillTriangles()
        {
            // создание треугольников верхней части призмы
            List<int> triangles = new();
            for (int i = EdgeCount - 1; i >= 2; i--)
            {
                var currentVertex = 0;
                var nextVertex = i;
                var subsequentForNextVertex = i - 1;

                triangles.Add(currentVertex);
                triangles.Add(nextVertex);
                triangles.Add(subsequentForNextVertex);
            }

            // создание треугольников нижней части призмы
            for (int i = EdgeCount; i < _vertices.Count - 2; i++)
            {
                var currentVertex = EdgeCount;
                var nextVertex = i + 1;
                var subsequentForNextVertex = i + 2;

                triangles.Add(currentVertex);
                triangles.Add(nextVertex);
                triangles.Add(subsequentForNextVertex);
            }

            return triangles;
        }

        private List<int> FillSideTriangles()
        {
            List<int> triangles = new List<int>();

            for (int i = 0; i < EdgeCount; i++)
            {
                var currentVertex = i;
                var nextVertex = i + 1;
                var nextRowVertex = i + EdgeCount;
                if ((i + 1) % EdgeCount == 0 && i != 0) // Если кончается ряд
                {
                    triangles.Add(currentVertex);
                    triangles.Add(currentVertex - EdgeCount + 1);
                    triangles.Add(nextVertex);
                    triangles.Add(nextVertex);
                    triangles.Add(nextRowVertex);
                    triangles.Add(currentVertex);
                }
                else
                {
                    triangles.Add(currentVertex);
                    triangles.Add(nextVertex);
                    triangles.Add(nextRowVertex);
                    triangles.Add(nextRowVertex);
                    triangles.Add(nextVertex);
                    triangles.Add(nextRowVertex + 1);
                }
            }

            return triangles;
        }
    }
}