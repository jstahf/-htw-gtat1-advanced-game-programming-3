using System;
using UnityEngine;

namespace SampleSceneAssets.Scripts
{
    public class AppleGenerator : MeshGenerator
    {
        [SerializeField] [Range(0.1f, 10)] private float a = Mathf.PI / 2;
        protected override Vector2 UMinMax => new Vector2(0, 2*Mathf.PI);
        protected override Vector2 VMinMax => new Vector2(-Mathf.PI, Mathf.PI);

        protected override Vector3 GenerateVertex(float u, float v)
        {

            return new Vector3(
                (float)(Mathf.Cos(u) * (4 + 3.8 * Mathf.Cos(v))),
                (float)((Mathf.Cos(v) + Mathf.Sin(v) - 1) * (1 + Mathf.Sin(v)) * Mathf.Log(1 - Mathf.PI * v / 10) + 7.5 * Mathf.Sin(v)),
                (float)(Mathf.Sin(u) * (4 + 3.8 * Mathf.Cos(v)))
            );

        }
    }
}
