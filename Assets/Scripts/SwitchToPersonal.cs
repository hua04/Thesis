using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToPersonal : MonoBehaviour
{
    public GameObject[] turnOff;
    public GameObject[] turnOn;
    public GameObject[] apps; 

    public void Awake()
    {
        turnOff = GameObject.FindGameObjectsWithTag("Work");
        turnOn = GameObject.FindGameObjectsWithTag("Personal");
        apps = GameObject.FindGameObjectsWithTag("App");
    }
    public void Start()
    {
        foreach (GameObject obj in turnOff)
        {
            obj.SetActive(false);
        }

    }
    public void SwitchPersonal()
    {
        foreach (GameObject obj in turnOn)
        {
            if (obj)
            {
                obj.SetActive(true);
            }
        }
        foreach (GameObject obj in apps)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in turnOff)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in apps)
        {
            obj.SetActive(false);
        }

    }
}
