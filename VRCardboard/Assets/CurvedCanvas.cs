using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedCanvas : MonoBehaviour
{
    public float curvature = 0.5f;

    void Start()
    {
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[4];
        Vector2[] uv = new Vector2[4];
        int[] triangles = new int[6];

        float width = GetComponent<RectTransform>().rect.width;
        float height = GetComponent<RectTransform>().rect.height;

        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(0, height, 0);
        vertices[2] = new Vector3(width, height, 0);
        vertices[3] = new Vector3(width, 0, 0);

        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(0, 1);
        uv[2] = new Vector2(1, 1);
        uv[3] = new Vector2(1, 0);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        GetComponent<MeshFilter>().mesh = mesh;

        float radius = curvature * height;

        for (int i = 0; i < vertices.Length; i++)
        {
            float x = vertices[i].x - width / 2;
            float y = vertices[i].y - height / 2;
            float z = Mathf.Sqrt(radius * radius - x * x) - radius;
            vertices[i].z = z;
        }

        mesh.vertices = vertices;
        mesh.RecalculateBounds();
    }
}
