using System;
using UnityEngine;

namespace SampleSceneAssets.Scripts.MaxScript
{
    public class GenTest : MeshGenerator
    {
        [SerializeField] [Range(0.1f, 10)] private float radius = 3;
        protected override Vector2 UMinMax => new Vector2(-1, 2 );//* Mathf.PI );
        protected override Vector2 VMinMax => new Vector2(0,  2 * Mathf.PI);

        protected override Vector3 GenerateVertex(float u, float v)
        {
            return new Vector3(
                radius * (3 * ( 1 + Mathf.Sin(v) + 2 * (1 - Mathf.Cos(v) / 2) * Mathf.Cos(u)) * Mathf.Cos(v)),
                radius * ((4 + 2 * (1 - Mathf.Cos(v) / 2) * Mathf.Cos(u)) * Mathf.Sin(v)),
                radius * (-2 * (1 - Mathf.Cos(v) / 2) * Mathf.Sin(u))
                );
        }
    }
}