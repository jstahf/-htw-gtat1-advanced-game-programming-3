using System;
using UnityEngine;

namespace SampleSceneAssets.Scripts.MaxScript
{
    public class GenSphere : MeshGenerator
    {
        [SerializeField] [Range(0.01f, 5)] private float radius = 3f;

        [SerializeField] [Range(0.01f, 1)] private float swirl = 0.05f;
        [SerializeField] [Range(0.0f, 50)] private float turn = 10;
        protected override Vector2 UMinMax => new Vector2(-Mathf.PI, Mathf.PI);
        protected override Vector2 VMinMax => new Vector2(-Mathf.PI, Mathf.PI);

        protected override Vector3 GenerateVertex(float u, float v)
        {
            return new Vector3(
                 radius * Mathf.Sin(v) * Mathf.Sin(u) + swirl*Mathf.Cos(turn*v), 
                 radius * Mathf.Cos(u) * Mathf.Sin(v) + swirl*Mathf.Cos(turn*u),
                 radius * Mathf.Cos(v)
            );
        }
    }
}