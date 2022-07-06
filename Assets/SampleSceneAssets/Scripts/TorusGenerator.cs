using UnityEngine;

namespace SampleSceneAssets.Scripts
{
    /// <summary>
    /// <c>TorusGenerator</c> is the implementation of the abstract <c>MeshGenerator</c> class and creates
    /// a Torus( better known to common folks as a donut). I used the explanation on wikipedia to implement this
    /// shape.
    /// </summary>
    public class TorusGenerator : MeshGenerator
    {
        protected override Vector2 UMinMax { get; } = new Vector2(0, 2 * Mathf.PI);
        protected override  Vector2 VMinMax { get; } = new Vector2(0, 2 * Mathf.PI);
        protected override Vector3 GenerateVertex(float u, float v)
        {
            return  new Vector3(
                Mathf.Sin(v),
                (2f + Mathf.Cos(v)) * Mathf.Sin(u), 
                (2f + Mathf.Cos(v)) * Mathf.Cos(u)
            );
        }
    }
}

