using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Capsule : Sphere
{
    [Space] [SerializeField] private float height;


    private void Start()
    {
        Generate();
    }
    
    protected override Vector3[] CreateVertices()
    {
        var heightHalf = height * 0.5f;
        for (int width = 1; width <= Smoothness * 0.5f; width++)
        {
            float theta = width * Mathf.PI / (Smoothness);
            for (int lon = 0; lon < Smoothness; lon++)
            {
                float phi = lon * 2 * Mathf.PI / Smoothness;
                float x = Radius * Mathf.Sin(theta) * Mathf.Cos(phi);
                float y = Radius * Mathf.Cos(theta);
                float z = Radius * Mathf.Sin(theta) * Mathf.Sin(phi);

                Vertices.Add(new Vector3(x, y + heightHalf, z));
            }
        }

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



}