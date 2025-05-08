using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickNoise : MonoBehaviour
{
    public AudioSource click;
    // Start is called before the first frame update
    public void Awake()
    {
        if (FindObjectsOfType<MouseClickNoise>().Length == 1)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            click.Play();
        }
    }
}
