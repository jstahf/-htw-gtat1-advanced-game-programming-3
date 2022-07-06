using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SampleSceneAssets.Scripts
{
    public class ClusterFuckGenerator : MeshGenerator
    {
        [SerializeField] [Range(0.01f, 3f)] private float size;
        protected override Vector2 UMinMax => new Vector2(0, 10);
        protected override Vector2 VMinMax => new Vector2(0, 10);

        protected override Vector3 GenerateVertex(float u, float v)
        {
            return new Vector3(
                Random.Range(-size, size),
                Random.Range(-size, size),
                Random.Range(-size, size)
                );
        }
    }
}
