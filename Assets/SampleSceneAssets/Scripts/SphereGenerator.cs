using System.Collections;
using System.Collections.Generic;
using SampleSceneAssets.Scripts;
using UnityEngine;

public class SphereGenerator : IGeneratorFunction
{

    public Vector2 UMinMax { get; } = new Vector2(0, 2 * Mathf.PI);
    public Vector2 VMinMax { get; } = new Vector2(0, Mathf.PI);
    public Vector3 GenerateVertex(float u, float v)
    {
        return  new Vector3(3f * Mathf.Cos(u) * Mathf.Sin(v),
            3f * Mathf.Sin(u) * Mathf.Sin(v), 3f * Mathf.Cos(v));
    }
}
