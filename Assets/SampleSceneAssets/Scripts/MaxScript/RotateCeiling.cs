using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCeiling : MonoBehaviour
{
    [SerializeField] public float rotationX = 5;
    [SerializeField] public float rotationY = 5;

    [SerializeField] public float rotationZ = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(rotationX, rotationY, rotationZ) * Time.deltaTime);

    }
}
