using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Interrupt2 : MonoBehaviour
{
    public GameObject popup;
    // Start is called before the first frame update
    void Start()
    {
        popup.SetActive(false);
    }
    public void InterruptGame()
    {
        popup.SetActive(true);


    }
}
