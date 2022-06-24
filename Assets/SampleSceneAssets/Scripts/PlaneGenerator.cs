
using System;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlaneGenerator : MonoBehaviour
{
    [SerializeField][Range(1, 100)] private int mSubDivisions;
    [SerializeField][Range(1, 100)] private int nSubDivisions;
    // Start is called before the first frame update
    void Start()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        if (mf == null)
        {
            Debug.LogError("did not find mesh filter assigned to this object cant generate mesh");
            return;
        }

        var mesh = GenerateMesh();
        mf.mesh = mesh;

    }
    protected Mesh GenerateMesh()
    {
     
        var mesh = new Mesh();
        Vector2Int subdivisions = new Vector2Int(mSubDivisions, nSubDivisions);
        var vertexSize = subdivisions + new Vector2Int(1, 1);
        var vertices = new Vector3[vertexSize.x * vertexSize.y];
        var uvs = new Vector2[vertices.Length];
        var uDelta = 2 * Mathf.PI;
        for (int y = 0; y < vertexSize.y; y++)
        {
            var v = (1f / subdivisions.y) * y;
            for (int x = 0; x < vertexSize.x; x++)
            {
                var u = (1f / subdivisions.x) * x;
                var scaledUV = new Vector2(u * uDelta, v * uDelta);
                var vertex = new Vector3(3f * Mathf.Cos(scaledUV.x) * Mathf.Sin(scaledUV.y) , 
                    3f * Mathf.Sin(scaledUV.x) * Mathf.Sin(scaledUV.y), 3f * Mathf.Cos(scaledUV.y));
                var uv = new Vector2(u, v);
                vertices[x + vertexSize.x * y] = vertex;
                uvs[x + vertexSize.x * y] = uv;
            }
        }

        var triangles = new int[3 * 2 * subdivisions.x * subdivisions.y];
        for (int i = 0; i < subdivisions.x * subdivisions.y; i++)
        {
            var triangleIndex = (i % subdivisions.x) + (i / subdivisions.x) * vertexSize.x;
            var indexer = i * 6;

            triangles[indexer] = triangleIndex;
            triangles[indexer + 1] = triangleIndex + subdivisions.x + 1;
            triangles[indexer + 2] = triangleIndex + 1;
            
            triangles[indexer + 3] = triangleIndex + 1;
            triangles[indexer + 4] = triangleIndex + subdivisions.x + 1;
            triangles[indexer + 5] =  triangleIndex + subdivisions.x + 2;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
        return mesh;
    }

}
