using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{

    private Renderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void OnMouseDown()
    {
        _renderer.material.color =
            _renderer.material.color == Color.red ? Color.blue : Color.red;
    }
    
    
}
