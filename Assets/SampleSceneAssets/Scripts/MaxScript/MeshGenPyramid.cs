/*
 using System;

using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.PlayerLoop;
[ExecuteInEditMode][RequireComponent(typeof(MeshFilter))]
public class MeshGenPyramid : MonoBehaviour
{
    
    Mesh mesh;
    Vector3[] vertices;
    int [] triangles;
    
    public int xSize = 20;
    public int zSize = 20;
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        //CreateShape();
        StartCoroutine(CreateShape());

        //OnDrawGizmos();
        
    }

    private void Update()
    {
        UpdateMesh();
    }


    // Update is called once per frame
    IEnumerator CreateShape()
    {
        vertices = new Vector3[(xSize/2 + 1) * (zSize + 1)];
        int i = 0;
        float y = 0;

        for (int z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                vertices[i] = new Vector3(x, 0, z);
                y += 0.1f;
                i++;
            }

            xSize -= 1;


        }

        triangles = new int[xSize * zSize * 6];
        
        int vert = 0;
        int tris = 0;
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                //triangles = new int[6];
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;

                yield return new WaitForSeconds(.01f);
            }

            vert++;
        }
    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
        
    }

    private void OnDrawGizmos()
    {
       if (vertices == null) return;
       for (int i = 0; i < vertices.Length; i++)
       {
           Gizmos.DrawSphere(vertices[i], .1f);
       }
    }
}
 */