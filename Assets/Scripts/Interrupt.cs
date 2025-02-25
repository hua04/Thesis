using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Interrupt : MonoBehaviour
{
    public GameObject exit;
    public GameObject popup;
    // Start is called before the first frame update
    void Start()
    {
        exit.SetActive(false);
        popup.SetActive(false);
    }

    [YarnCommand("interrupt")]
    public void InterruptGame()
    {
        popup.SetActive(true);
        exit.SetActive(true);
    }
}
