using System.Collections.Generic;
using UnityEngine;

public class ActiveConvoIndicator : MonoBehaviour
{
    public List<GameObject> indicators;
    public void SetIndicator(bool active, Location loc)
    {

        if (loc!= Location.gameWindow&&loc != Location.none)
        {
            indicators[(int)loc-1].SetActive(active);
            Debug.Log("going");
        }
            
       
        
    }
}
