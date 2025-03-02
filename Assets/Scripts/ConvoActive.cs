using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConvoActive : MonoBehaviour
{
    public int convoCount;
    public GameObject convos;
    public GameObject[] allConvos;
    public GameObject thisConvo;
    public GameObject[] selectionHighlight;
    public GameObject thisSelect;
    public void Awake()
    {
        convoCount = convos.transform.childCount;
        allConvos = GameObject.FindGameObjectsWithTag("Convo");
        selectionHighlight = GameObject.FindGameObjectsWithTag("Select");
    }
    public void Start()
    {
        
        foreach (GameObject convo in allConvos)
        {
            var test = convo.name;
            Debug.Log(test);
        }
        
        Debug.Log(selectionHighlight);
        if (thisSelect.transform.parent.name!="Boss button")
        {
            thisSelect.SetActive(false);
        }
    }
    public void ConvoSelected()
    {
        thisConvo.transform.SetSiblingIndex(convoCount-1);
        foreach (GameObject select in selectionHighlight)
        {
            select.SetActive(false);
            Debug.Log(1);
           
        }

        thisSelect.SetActive(true);
      
    }

}
