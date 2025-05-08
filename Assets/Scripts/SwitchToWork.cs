using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToWork : MonoBehaviour
{
    public List<GameObject> turnOff;
    public List<GameObject> turnOn;
    public List<GameObject> apps;

    public void Awake()
    {
        turnOn.AddRange(GameObject.FindGameObjectsWithTag("Work"));
        turnOff.AddRange(GameObject.FindGameObjectsWithTag("Personal"));
        apps.AddRange(GameObject.FindGameObjectsWithTag("App"));
    }

    public void AdjustWork(GameObject app)
    {
        turnOn.Remove(app);
        apps.Remove(app);
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
