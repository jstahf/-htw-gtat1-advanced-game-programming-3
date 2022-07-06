using System.Collections;
using UnityEngine;

namespace SampleSceneAssets.Scripts
{
    /// <summary>
    /// <c>CameraRotator</c> can be attached to a GameObject
    /// to rotate it around the Y-Axis in steady intervals. It works by using
    /// a coroutine and pausing for x seconds. The angle can be adjusted by
    /// a slider in the editor and the camera rotates to -rotationRange/2 to rotationRange/2
    /// </summary>
    public class CameraRotator : MonoBehaviour
    {
        
        [SerializeField] [Range(0, 180)] private float rotationRange;
        [SerializeField] [Range(1, 20)] private float rotationSpeed;
        private float directionSign = 1;
  
        private float currentAngle = 0;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Rotate());
        }
        /// <summary>
        /// Method <c>Rotate</c> is used to rotate each iteration the transform.Rotate
        /// method ist used which adds the given angle. If the angle reaches <c>rotationRange</c>
        /// the method pauses for two seconds and continuous in the other direction
        /// </summary>
        private IEnumerator Rotate()
        {
            while (true)
            {
                while (Mathf.Abs(currentAngle) <= rotationRange / 2)
                {
                    currentAngle += directionSign * (rotationSpeed * Time.deltaTime);
                
                    transform.Rotate(Vector3.up, directionSign * (rotationSpeed * Time.deltaTime));
                    yield return new WaitForSeconds(0.1f);
                }
                currentAngle = directionSign * rotationRange / 2;
                directionSign *= -1;
                yield return new WaitForSeconds(2f);
            }
        }
    }
}