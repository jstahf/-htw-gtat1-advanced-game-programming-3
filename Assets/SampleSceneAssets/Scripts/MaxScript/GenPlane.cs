using System;
using UnityEngine;

namespace SampleSceneAssets.Scripts.MaxScript
{
    public class GenPlane : MeshGenerator
    {
        protected override Vector2 UMinMax => new Vector2(0,1);
        protected override Vector2 VMinMax => new Vector2(0,1);

        protected override Vector3 GenerateVertex(float u, float v)
        {
            return new Vector3(u, v, 0);
        }
    }
}
