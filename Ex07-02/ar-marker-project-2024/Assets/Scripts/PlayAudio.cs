using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponentInChildren<AudioSource>();
    }

    public void OnMouseDown()
    {
        audio.Play();
    }
}
