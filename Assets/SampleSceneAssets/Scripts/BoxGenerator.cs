using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGenerator : MonoBehaviour
{
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
        mesh.vertices = new Vector3[]
        {
            new Vector3(0, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(1, 0, 0),
            new Vector3(1, 1, 0)
        };
        mesh.triangles = new[] {0, 1, 2, 1, 3, 2};
        mesh.uv = getUVs(mesh);
        return mesh;
    }

    protected Vector2[] getUVs(Mesh mesh)
    {
        Vector2[] uvs = new Vector2[mesh.vertices.Length];
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            uvs[i] = mesh.vertices[i];
        }

        return uvs;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
}
