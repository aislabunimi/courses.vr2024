using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDragAndMove : MonoBehaviour
{
    [Range(0f, 2f)]
    public float dragSpeed = 0.0005f;

    private Vector3 dragOrigin;

    private Vector3 cameraOriginalPos;

    private Camera camera;
    
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        cameraOriginalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {

        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = camera.ScreenToViewportPoint(dragOrigin - Input.mousePosition);
        Vector3 move = new Vector3(pos.x * dragSpeed * Time.deltaTime, pos.y * dragSpeed * Time.deltaTime, 0f);
        
        transform.Translate(move, Space.World);
    }

    public void Zoom(float zoom)
    {
        transform.Translate(0, 0 , zoom);
    }

    public void Reset()
    {
        transform.position = cameraOriginalPos;
    }
}
