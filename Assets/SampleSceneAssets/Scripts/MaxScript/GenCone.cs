using System;
using UnityEngine;

namespace SampleSceneAssets.Scripts.MaxScript
{
    public class GenCone : MeshGenerator
    {
        [SerializeField] [Range(0.1f, 10)] private float radius = 3;
        protected override Vector2 UMinMax => new Vector2(0, 2 * Mathf.PI);
        protected override Vector2 VMinMax => new Vector2(0, 2* Mathf.PI);

        protected override Vector3 GenerateVertex(float u, float v)
        {
            return new Vector3(
                u * Mathf.Cos(v), 
                u * Mathf.Sin(v), 
                u
            );
        }
    }
}