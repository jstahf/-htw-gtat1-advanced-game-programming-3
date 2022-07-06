using System.Collections;
using UnityEngine;

namespace SampleSceneAssets.Scripts.MaxScript
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(MeshFilter))]
    public class Treppe : MonoBehaviour
    {
        private Mesh mesh;

        private Vector3[] vertices;

        private int[] triangles;
        [SerializeField] public int stepDepth = 5; //Stufentiefe
        [SerializeField] public int stephWidth = 15; //Laufbreite
        [SerializeField] public int stepHeight = 5; // Stufenhöhe
        [SerializeField] public int amountStages = 10; // Stufenanzahl

        // Start is called before the first frame update
        void Start()
        {
            mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = mesh;
            //CreateShape();
            StartCoroutine(CreateShape());

        }
        private void Update()
        {
            UpdateMesh();
        }

        private IEnumerator CreateShape()
        {
            vertices = new Vector3[(stepDepth + 1) * (stephWidth + 1) * (stepHeight + 1) * (amountStages + 1)];

            //iterations
            int i = 0;
            // Loop for amount of stages / steps
            for (int s = 0; s <= amountStages; s++)
            {
                // Loop for step Height
                for (int y = 0; y <= stepHeight; y++)
                {
                    // loop for the first tier (depth x width)
                    for (int z = 0; z <= stepDepth; z++) 
                    {
                        //loop step width 
                        for (int x = 0; x <= stephWidth; x++)
                        {
                            vertices[i] = new Vector3(x, y, z);
                        }
                    }
                }
            }

            triangles = new int[stephWidth * stepDepth * stepHeight * amountStages * 6];

            int vert = 0;
            int tris = 0;
            for (int s = 0; s <= amountStages; s++)
            {
                for (int y = 0; y < stepHeight; y++)
                {
                    for (int z = 0; z <= stepDepth; z++)
                    {
                        for (int x = 0; x <= stephWidth; x++)
                        {
                            triangles[tris + 0] = vert + 0;
                            triangles[tris + 1] = vert + stephWidth + stepHeight + 1;
                            triangles[tris + 2] = vert + 1;
                            triangles[tris + 3] = vert + 1;
                            triangles[tris + 4] = vert + stephWidth + 1;
                            triangles[tris + 5] = vert + stephWidth + 2;

                            vert++;
                            tris += 6;
                        
                            yield return new WaitForSeconds(.01f);

                        }
                        vert++;
                    }
                    vert++;
                } 
                vert++;
            }
        }


        // Update is called once per frame
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
}

