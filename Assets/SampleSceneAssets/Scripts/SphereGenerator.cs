using UnityEngine;

namespace SampleSceneAssets.Scripts
{
    /// <summary>
    /// <c>SphereGenerator</c> is the implementation of the abstract <c>MeshGenerator</c> class and creates
    /// a sphere with an adjustable Radius. I implemented this myself to test the MeshGenerator class
    /// because the formula for sphere is somewhat intuitive.
    /// </summary>
    public class SphereGenerator : MeshGenerator
    {
        [SerializeField] [Range(0.1f, 10)] private float radius = 3;
        protected override Vector2 UMinMax => new Vector2(0, 2 * Mathf.PI);
        protected override Vector2 VMinMax => new Vector2(0, Mathf.PI);

        protected override Vector3 GenerateVertex(float u, float v)
        {
            return  new Vector3(
                radius * Mathf.Cos(u) * Mathf.Sin(v),
                radius * Mathf.Sin(u) * Mathf.Sin(v), 
                radius * Mathf.Cos(v)
            );
        }
    }
}
