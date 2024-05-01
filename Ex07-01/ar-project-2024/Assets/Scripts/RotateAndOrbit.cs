using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAndOrbit : MonoBehaviour
{
    private Transform sunTransform;

    private float _rotationSpeed = 0.1f;

    public bool startMovement = false;
    
    // Start is called before the first frame update
    void Start()
    {
        sunTransform = GameObject.FindGameObjectWithTag("sun").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startMovement)
        {
            transform.RotateAround(sunTransform.transform.position, Vector3.up, 5 * Time.deltaTime);
            transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
        }
        
    }

    public void StartMovement(Vector3 startingPoint, float rotationSpeed, float scaleRadius)
    {
        transform.position = startingPoint;
        transform.localScale *= scaleRadius;
        _rotationSpeed = rotationSpeed;
        startMovement = true;

    }
}
