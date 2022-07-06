using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SampleSceneAssets.Scripts
{
    public class BonBonGenerator : MeshGenerator
    {
        protected override Vector2 UMinMax => new Vector2(0, 2 * Mathf.PI);
        protected override Vector2 VMinMax => new Vector2(0, Mathf.PI);

        protected override Vector3 GenerateVertex(float u, float v)
        {
            return new Vector3(
                u,
                Mathf.Cos(u) * Mathf.Cos(v),
                Mathf.Cos(u) * Mathf.Sin(v)
                );
        }
    }
}
