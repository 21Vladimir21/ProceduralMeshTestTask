using System.Collections.Generic;
using Enums;
using ShapeParameters;
using UnityEngine;

namespace Figures
{
    public abstract class ShapeBase : MonoBehaviour
    {
        [field: SerializeField] public EShapesType Type { get; private set; }
        [SerializeField] protected MeshFilter meshFilter;
        [SerializeField] protected MeshRenderer meshRenderer;
        [SerializeField] private MeshCollider meshCollider;

        [SerializeField] protected Material material;
        public virtual List<IParameter> Parameters { get; set; }

        protected void Generate()
        {
            if (meshRenderer.material == null)
            {
                var cloneMaterial = new Material(material);
                meshRenderer.material = cloneMaterial;
            }

            var mesh = new Mesh();
            meshFilter.mesh.Clear();
            mesh.vertices = CreateVertices();
            mesh.triangles = CreateTriangles();
            mesh.RecalculateNormals();
            meshFilter.mesh = mesh;
            meshCollider.sharedMesh = mesh;
        }

        public void ChangeColor(Color color) => meshRenderer.material.color = color;
        public virtual void ChangeSize(List<IParameter> parameters) => Generate();

        protected abstract Vector3[] CreateVertices();
        protected abstract int[] CreateTriangles();

        protected T GetValue<T>(EParameters type, List<IParameter> parameters) where T : struct
        {
            foreach (var parameter in parameters)
                if (parameter.Type == type)
                    if (parameter is ShapeParameter<T> value)
                        return value.Value;
            return default;
        }

#if UNITY_EDITOR

        private void OnValidate()
        {
            if (meshRenderer == null) meshRenderer = GetComponent<MeshRenderer>();
            if (meshFilter == null) meshFilter = GetComponent<MeshFilter>();
            if (meshCollider == null) meshCollider = GetComponent<MeshCollider>();
        }
#endif
    }
}