using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToPersonal : MonoBehaviour
{
    public List<GameObject> turnOff;
    public List<GameObject> turnOn;
    public List<GameObject> apps; 

    public void Awake()
    {
        turnOff.AddRange(GameObject.FindGameObjectsWithTag("Work"));
        turnOn.AddRange(GameObject.FindGameObjectsWithTag("Personal"));
        apps.AddRange(GameObject.FindGameObjectsWithTag("App"));
    }
    public void Start()
    {
        foreach (GameObject obj in turnOff)
        {
            obj.SetActive(false);
        }

    }

    public void AdjustWork(GameObject app)
    {
        turnOff.Remove(app);
        apps.Remove(app);
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
