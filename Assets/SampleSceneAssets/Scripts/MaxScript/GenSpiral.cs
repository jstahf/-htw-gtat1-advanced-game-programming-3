using System;
using UnityEngine;

namespace SampleSceneAssets.Scripts.MaxScript
{
    public class GenSpiral : MeshGenerator
    {
        [SerializeField] [Range(0.1f, 10)] private float radius = 3;
        [SerializeField] [Range(0.0f, 10)] private float height = 1f;

        [SerializeField] [Range(0.0f, 10)] private float turns = 1f / 2;

        protected override Vector2 UMinMax => new Vector2(-height, height);
        protected override Vector2 VMinMax => new Vector2(Mathf.PI *-turns,Mathf.PI * turns);
        protected override Vector3 GenerateVertex(float u, float v)
        {
            //float Delta = Mathf.Sin(u*20) + Mathf.Sin(u)
            return new Vector3(
                u * Mathf.Cos(v) * radius,
                u * Mathf.Sin(v) * radius,
                v
            );
        }
    }
}