using UnityEngine;

namespace SampleSceneAssets.Scripts
{
    public class CapsuleGenerator : MeshGenerator
    {
        [SerializeField] [Range(0.1f, 10)] private float radius = 3;
        [SerializeField] [Range(0.1f, 10)] private float length = 3;
        [SerializeField] [Range(0f, 10)] private float endlength = 1;
        protected override Vector2 UMinMax => new Vector2(0, 2 * Mathf.PI);
        protected override Vector2 VMinMax => new Vector2(0, Mathf.PI);

        protected override Vector3 GenerateVertex(float u, float v)
        {
            if (v < VMinMax.y / 2) {
                return new Vector3(
                    radius * Mathf.Cos(u) * Mathf.Sin(v),
                    radius * Mathf.Sin(u) * Mathf.Sin(v),
                    length + radius * Mathf.Cos(v) * endlength
                );
            } else if (v > VMinMax.y / 2)
            {
                return new Vector3(
                    radius * Mathf.Cos(u) * Mathf.Sin(v),
                    radius * Mathf.Sin(u) * Mathf.Sin(v),
                    -length + radius * Mathf.Cos(v) * endlength
                );
            }
            {
                return new Vector3(
                    radius * Mathf.Cos(u) * Mathf.Sin(v),
                    0,
                    radius * Mathf.Cos(v)
                );
            }
        }
    }
}
