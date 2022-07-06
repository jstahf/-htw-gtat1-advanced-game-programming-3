using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace SampleSceneAssets.Scripts.MaxScript
{ 
    public abstract class MeshGenerator : MonoBehaviour

    {

        [SerializeField] public int subdivision = 8;
        protected abstract Vector2 UMinMax { get; }
        protected abstract Vector2 VMinMax { get; }
        protected abstract Vector3 GenerateVertex(float u, float v);
        //public Mesh Mesh { get; set; }
        
        void Start()
        {
            Debug.Log("Start");

            MeshFilter meshFilter = GetComponent<MeshFilter>();
            Mesh mesh = GenerateMesh();
            
            meshFilter.mesh = mesh;

            Debug.Log("GameOver");

        }

        protected Mesh GenerateMesh()
        {
            Mesh mesh = new Mesh();
            Debug.Log("GenerateMesh");
            var subdivisions = new Vector2Int(subdivision, subdivision);
            var vertexSize = subdivisions + new Vector2Int(1, 1);
            var vertices = new Vector3[vertexSize.x * vertexSize.y];
            var uvs = new Vector2[vertices.Length];

            float uDelta = UMinMax.y - UMinMax.x;
            float vDelta = VMinMax.y - UMinMax.x;
            for (var y = 0; y < vertexSize.y; y++)
            {
                float v = (1f / subdivisions.y) * y;
                for (var x = 0; x < vertexSize.x; x++)
                {
                    float u = (1f / subdivisions.x) * x;
                    Vector2 scaleUV = new Vector2(u * uDelta + UMinMax.x, v * vDelta + VMinMax.x);
                    Vector3 vertex = GenerateVertex(scaleUV.x, scaleUV.y);
                    Vector2 uv = new Vector2(u, v);

                    //var arrayIndex = x + y * vertexSize.x; // vertices index
                    vertices[x + y * vertexSize.x] = vertex;
                    uvs[x + y * vertexSize.x] = uv;
                }
            }

            // generate Triangles
            Debug.Log("generate Triangles");

            var triangles = new int[subdivisions.x * subdivisions.y * 6];
            for (var i = 0; i < subdivisions.x * subdivisions.y; i ++)
            {
                var triangleIndex = (i % subdivisions.x) + (i / subdivisions.x) * vertexSize.x;
                var indexer = i * 6;

                triangles[indexer + 0] = triangleIndex;
                triangles[indexer + 1] = triangleIndex + subdivisions.x + 1;
                triangles[indexer + 2] = triangleIndex + 1;

                triangles[indexer + 3] = triangleIndex + 1;
                triangles[indexer + 4] = triangleIndex + subdivisions.x + 1;
                triangles[indexer + 5] = triangleIndex + subdivisions.x + 2;
            }
            // Recalclate Mesh
            mesh.vertices = vertices;
            mesh.uv = uvs;
            mesh.triangles = triangles;
            mesh.RecalculateBounds();
            mesh.RecalculateNormals();
            mesh.RecalculateTangents();
            
            //GetComponent<MeshFilter>().mesh = generatedMesh;
            return mesh;
            
        }
    }
}
