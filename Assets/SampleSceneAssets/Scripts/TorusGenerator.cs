using System;
using System.Collections;
using System.Collections.Generic;
using SampleSceneAssets.Scripts;
using UnityEngine;

public class TorusGenerator : IGeneratorFunction
{

    public Vector2 UMinMax { get; } = new Vector2(0, 2 * Mathf.PI);
    public Vector2 VMinMax { get; } = new Vector2(0, 2 * Mathf.PI);
    public Vector3 GenerateVertex(float u, float v)
    {
        return  new Vector3(Mathf.Sin(v),
            (5f + Mathf.Cos(v)) * Mathf.Sin(u), (5f + Mathf.Cos(v)) * Mathf.Cos(u));
    }
}

