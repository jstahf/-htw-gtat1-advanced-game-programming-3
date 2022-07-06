using UnityEngine;

namespace SampleSceneAssets.Scripts
{
    public class PlaneGenerator : MeshGenerator
    {
        protected override Vector2 UMinMax => new Vector2(0, 1);
        protected override Vector2 VMinMax => new Vector2(0, 1);
        protected override Vector3 GenerateVertex(float u, float v)
        {
            return new Vector3(u, 0, v);
        }
    }
}