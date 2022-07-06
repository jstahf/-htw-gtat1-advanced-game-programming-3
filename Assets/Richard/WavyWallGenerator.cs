using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SampleSceneAssets.Scripts
{
    public class WavyWallGenerator : MeshGenerator
    {
        protected override Vector2 UMinMax => new Vector2(0, 10);
        protected override Vector2 VMinMax => new Vector2(0, 2 * Mathf.PI);

        protected override Vector3 GenerateVertex(float u, float v)
        {
            return new Vector3(
                Mathf.Cos((u * Mathf.PI) / 6) * Mathf.Cos(v),
                v,
                u
                );
        }
    }
}
