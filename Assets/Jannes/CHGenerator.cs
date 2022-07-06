using System;
using UnityEngine;

namespace SampleSceneAssets.Scripts
{
    public class CHGenerator : MeshGenerator
    {
        [SerializeField] [Range(0.1f, 10)] private float a = Mathf.PI / 2;
        protected override Vector2 UMinMax => new Vector2(-2*Mathf.PI, 2*Mathf.PI);
        protected override Vector2 VMinMax => new Vector2(-2, 2);

        protected override Vector3 GenerateVertex(float u, float v)
        {
            return new Vector3(
                (float) (Mathf.Cos(a) * Mathf.Cos(u) * Math.Cosh(v) + Mathf.Sin(a) * Mathf.Sin(u) * Math.Sinh(v)),
                Mathf.Cos(a) * v + Mathf.Sin(a) * u,
                (float)(-Mathf.Cos(a) * Mathf.Sin(u) * Math.Cosh(v) + Mathf.Sin(a) * Mathf.Cos(u) * Math.Sinh(v))
            );
           
        }
    }
}
