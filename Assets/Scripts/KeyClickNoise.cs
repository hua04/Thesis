using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyClickNoise : MonoBehaviour
{
    public AudioSource tap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            tap.Play(); 
        }
    }
}
