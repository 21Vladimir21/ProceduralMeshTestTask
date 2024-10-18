using UnityEngine;

namespace Figures
{
    public abstract class FigureBase : MonoBehaviour
    {
        [field: SerializeField] public FiguresType Type { get; private set; }
        [SerializeField] protected MeshFilter meshFilter;
        [SerializeField] protected MeshRenderer meshRenderer;
        [SerializeField] private MeshCollider meshCollider;

        [SerializeField] protected Material material;


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

        protected abstract Vector3[] CreateVertices();
        protected abstract int[] CreateTriangles();

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