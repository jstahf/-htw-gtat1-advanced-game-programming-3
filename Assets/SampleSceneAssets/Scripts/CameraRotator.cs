using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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