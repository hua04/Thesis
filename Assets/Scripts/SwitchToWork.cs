using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToWork : MonoBehaviour
{
    public GameObject[] turnOff;
    public GameObject[] turnOn;
    public GameObject[] apps;

    public void Awake()
    {
        turnOn = GameObject.FindGameObjectsWithTag("Work");
        turnOff = GameObject.FindGameObjectsWithTag("Personal");
        apps = GameObject.FindGameObjectsWithTag("App");
        Debug.Log(turnOn);
        Debug.Log(turnOff);

    }
    public void SwitchWork()
    {
      
       
        foreach (GameObject obj in turnOn)
        {
      
                obj.SetActive(true);


        }
        foreach (GameObject obj in apps)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in turnOff)
        {
            obj.SetActive(false);
        }
 
    }
}
