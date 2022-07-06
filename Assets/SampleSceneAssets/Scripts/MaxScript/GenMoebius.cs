using System;
using UnityEngine;

namespace SampleSceneAssets.Scripts.MaxScript
{
    public class GenMoebius : MeshGenerator
    {
        [SerializeField] [Range(0.1f, 10)] private float radius = 3;
        [SerializeField] [Range(0.0f, 10)] private float T = 1f;

        protected override Vector2 UMinMax => new Vector2(-Mathf.PI, Mathf.PI);
        protected override Vector2 VMinMax => new Vector2(-1,1);
        protected override Vector3 GenerateVertex(float u, float v)
        {
            return new Vector3(
                (radius + T * v * Mathf.Cos(T * u)) * Mathf.Cos(u),
                (radius + T * v * Mathf.Cos(T * u)) * Mathf.Sin(u),
                T * v * Mathf.Sin(T*u)
            );
        }
    }
}