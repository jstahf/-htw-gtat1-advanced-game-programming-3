using System;
using UnityEngine;

namespace SampleSceneAssets.Scripts
{
    public class KleinGenerator: MeshGenerator
    {
        
        protected override Vector2 UMinMax { get; } = new Vector2(0, 2 * Mathf.PI);
        protected override Vector2 VMinMax { get; } = new Vector2(0, 2 * Mathf.PI );
        protected override Vector3 GenerateVertex(float u, float v)
        {
            return  new Vector3(
                (2 + Mathf.Cos(u / 2) * Mathf.Sin(v) - Mathf.Sin(u / 2) * Mathf.Sin(2 * v)) * Mathf.Cos(u), 
                (2 + Mathf.Cos(u / 2) * Mathf.Sin(v) - Mathf.Sin(u / 2) * Mathf.Sin(2 * v)) * Mathf.Sin(u),
                Mathf.Sin(u / 2) * Mathf.Sin(v) + Mathf.Cos(u/ 2) * Mathf.Sin(2 * v)
            );
        }
    }

}