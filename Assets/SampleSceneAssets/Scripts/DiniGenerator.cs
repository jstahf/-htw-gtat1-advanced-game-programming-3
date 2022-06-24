using UnityEngine;

namespace SampleSceneAssets.Scripts
{
    public class DiniGenerator: IGeneratorFunction
    {
        
        public Vector2 UMinMax { get; } = new Vector2(0, 4 * Mathf.PI);
        public Vector2 VMinMax { get; } = new Vector2(0.01f, 1 );
        public Vector3 GenerateVertex(float u, float v)
        {
            return  new Vector3(Mathf.Cos(u) * Mathf.Sin(v), Mathf.Sin(u) * Mathf.Sin(v),
                Mathf.Cos(v)+ Mathf.Log(Mathf.Tan(v / 2.0f)) + 0.15f * u);
        }
    }

}