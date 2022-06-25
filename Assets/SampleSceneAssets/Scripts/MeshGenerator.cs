using System;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace SampleSceneAssets.Scripts
{
 
    public abstract class MeshGenerator : MonoBehaviour
    {
        [SerializeField] [Range(1, 100)] private int mSubDivisions = 33;

        [SerializeField] [Range(1, 100)] private int nSubDivisions = 33;
        protected abstract Vector2 UMinMax { get; }
        protected abstract Vector2 VMinMax { get; }
        protected abstract Vector3 GenerateVertex(float u, float v);
        // Start is called before the first frame update
        private void Awake()
        {
      
        }

        void Start()
        {
            MeshFilter mf = GetComponent<MeshFilter>();
            if (mf == null)
            {
                Debug.LogError("did not find mesh filter assigned to this object cant generate mesh");
                return;
            }

            Mesh mesh = GenerateMesh();
            mf.mesh = mesh;
        }

        protected Mesh GenerateMesh()
        {
            Mesh mesh = new Mesh();
            Vector2Int subdivisions = new Vector2Int(mSubDivisions, nSubDivisions);
            Vector2Int vertexSize = subdivisions + new Vector2Int(1, 1);
            Vector3[] vertices = new Vector3[vertexSize.x * vertexSize.y];
            Vector2[] uvs = new Vector2[vertices.Length];
            float uDelta = UMinMax.y - UMinMax.x;
            float vDelta = VMinMax.y - VMinMax.x;
            for (int y = 0; y < vertexSize.y; y++)
            {
                float v = (1f / subdivisions.y) * y;
                for (int x = 0; x < vertexSize.x; x++)
                {
                    float u = (1f / subdivisions.x) * x;
                    Vector2 scaledUV = new Vector2(u * uDelta + UMinMax.x, v * vDelta + VMinMax.x);
                    Vector3 vertex = GenerateVertex(scaledUV.x, scaledUV.y);
                    Vector2 uv = new Vector2(u, v);
                    vertices[x + vertexSize.x * y] = vertex;
                    uvs[x + vertexSize.x * y] = uv;
                }
            }

            int[] triangles = GenerateTriangles(subdivisions, vertexSize);

            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.uv = uvs;
            mesh.RecalculateBounds();
            mesh.RecalculateNormals();
            mesh.RecalculateTangents();
            return mesh;
        }

        private static int[] GenerateTriangles(Vector2Int subdivisions, Vector2Int vertexSize)
        {
            int[] triangles = new int[3 * 2 * subdivisions.x * subdivisions.y];
            for (int i = 0; i < subdivisions.x * subdivisions.y; i++)
            {
                int triangleIndex = (i % subdivisions.x) + (i / subdivisions.x) * vertexSize.x;
                int indexer = i * 6;

                triangles[indexer] = triangleIndex;
                triangles[indexer + 1] = triangleIndex + subdivisions.x + 1;
                triangles[indexer + 2] = triangleIndex + 1;

                triangles[indexer + 3] = triangleIndex + 1;
                triangles[indexer + 4] = triangleIndex + subdivisions.x + 1;
                triangles[indexer + 5] = triangleIndex + subdivisions.x + 2;
            }

            return triangles;
        }
    }
}