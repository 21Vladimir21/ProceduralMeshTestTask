using System.Collections.Generic;
using Enums;
using Figures;
using ShapeParameters;
using UnityEngine;

namespace Shapes
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class Sphere : ShapeBase
    {
        [field: Space] [field: SerializeField] public int Smoothness { get; protected set; } = 10;
        [field: SerializeField] public float Radius { get; protected set; } = 1f;

        protected readonly List<Vector3> Vertices = new();

        public override List<IParameter> Parameters
        {
            get
            {
                var list = new List<IParameter>()
                {
                    new IntegerParameterValue(EParameters.Smoothness, Smoothness),
                    new FloatParameterValue(EParameters.Radius, Radius)
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
            base.ChangeSize(parameters);
        }

        protected override Vector3[] CreateVertices()
        {
            for (int width = 1; width <= Smoothness; width++)
            {
                float theta = width * Mathf.PI / (Smoothness + 1);
                for (int lon = 0; lon < Smoothness; lon++)
                {
                    float phi = lon * 2 * Mathf.PI / Smoothness;
                    float x = Radius * Mathf.Sin(theta) * Mathf.Cos(phi);
                    float y = Radius * Mathf.Cos(theta);
                    float z = Radius * Mathf.Sin(theta) * Mathf.Sin(phi);

                    Vertices.Add(new Vector3(x, y, z));
                }
            }

            Vertices.Add(new Vector3(0, Radius, 0));
            Vertices.Add(new Vector3(0, -Radius, 0));

            return Vertices.ToArray();
        }

        protected override int[] CreateTriangles()
        {
            var triangles = new List<int>();
            triangles.AddRange(FillSideTriangles());
            triangles.AddRange(FillUpTriangles());
            triangles.AddRange(FillBottomTriangles());
            return triangles.ToArray();
        }

        private List<int> FillSideTriangles()
        {
            List<int> triangles = new List<int>();

            for (int i = 0; i < (Smoothness * Smoothness) - Smoothness; i++)
            {
                var currentVertex = i;
                var nextVertex = i + 1;
                var nextRowVertex = i + Smoothness;
                if ((i + 1) % Smoothness == 0 && i != 0)
                {
                    triangles.Add(currentVertex);
                    triangles.Add(currentVertex - Smoothness + 1);
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

        private List<int> FillUpTriangles()
        {
            var upVertexIndex = Vertices.Count - 2;
            List<int> triangles = new();
            for (int i = 0; i < Smoothness; i++)
            {
                var currentVertex = i;
                var nextVertex = i + 1;
                if ((i + 1) % Smoothness == 0 && i != 0)
                {
                    triangles.Add(currentVertex);
                    triangles.Add(upVertexIndex);
                    triangles.Add(currentVertex - Smoothness + 1);
                }
                else
                {
                    triangles.Add(currentVertex);
                    triangles.Add(upVertexIndex);
                    triangles.Add(nextVertex);
                }
            }

            return triangles;
        }

        private List<int> FillBottomTriangles()
        {
            var upVertexIndex = Vertices.Count - 1;
            List<int> triangles = new();
            for (int i = Vertices.Count - 2 - Smoothness; i < Vertices.Count - 2; i++)
            {
                var currentVertex = i;
                var nextVertex = i + 1;
                if ((i + 1) % Smoothness == 0 && i != 0)
                {
                    triangles.Add(upVertexIndex);
                    triangles.Add(currentVertex);
                    triangles.Add(currentVertex - Smoothness + 1);
                }
                else
                {
                    triangles.Add(upVertexIndex);
                    triangles.Add(currentVertex);
                    triangles.Add(nextVertex);
                }
            }

            return triangles;
        }
    }
}