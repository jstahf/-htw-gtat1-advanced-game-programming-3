using System.Collections;
using System.Collections.Generic;
using SampleSceneAssets.Scripts;
using UnityEngine;

public class SphereGenerator : MeshGenerator
{
    [SerializeField] [Range(0.1f, 10)] private float radius = 3;
    protected override Vector2 UMinMax  => new Vector2(0, 2 * Mathf.PI);
    protected override Vector2 VMinMax => new Vector2(0, Mathf.PI);

    protected override Vector3 GenerateVertex(float u, float v)
    {
        return  new Vector3(radius * Mathf.Cos(u) * Mathf.Sin(v),
            radius * Mathf.Sin(u) * Mathf.Sin(v), radius * Mathf.Cos(v));
    }
}
