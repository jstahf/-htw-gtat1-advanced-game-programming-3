using UnityEngine;

namespace SampleSceneAssets.Scripts
{
    public enum MeshType {
        Torus,
        Sphere,
        Dini,
        Klein,
        Plane,
    }
    /// <summary>
    /// <c>MeshGeneratorWrapper</c> is mainly a class for debugging to eliminate the need to change out the mesh
    /// generator implementations. it can be used by creating a new Enum and instantiating the related
    /// Generator in the correct switch case.
    /// </summary>
    public class MeshGeneratorWrapper : MonoBehaviour
    {
        [SerializeField] private MeshType selectedMesh;
        private MeshType prevSelection;
        private MeshGenerator currMeshGen;
        private void Awake()
        {
            prevSelection = selectedMesh;
            InstantiateNewMeshGen();
        }
  

        private void Update()
        {
            if (selectedMesh != prevSelection)
            {
                Debug.Log("type changed");
                prevSelection = selectedMesh;
                InstantiateNewMeshGen();
            }
        }

        private void InstantiateNewMeshGen()
        {
            Destroy(currMeshGen);
            switch (selectedMesh)
            {
                case MeshType.Sphere:
                    gameObject.AddComponent<SphereGenerator>();
                    break;
                case MeshType.Torus:
                    gameObject.AddComponent<TorusGenerator>(); 
                    break;
                case MeshType.Dini:
                    gameObject.AddComponent<DiniGenerator>(); 
                    break;
                case MeshType.Klein:
                    gameObject.AddComponent<KleinGenerator>(); 
                    break;
                default:
                    gameObject.AddComponent<PlaneGenerator>();
                    break;
            }
        }
    }
}
