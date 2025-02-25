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
    public void Start()
    {
        convoCount = convos.transform.childCount;
        allConvos = GameObject.FindGameObjectsWithTag("Convo");
        foreach (GameObject convo in allConvos)
        {
            var test = convo.name;
            Debug.Log(test);
        }
        selectionHighlight = GameObject.FindGameObjectsWithTag("Select");

    }
    public void ConvoSelected()
    {
        thisConvo.transform.SetSiblingIndex(convoCount-1);
        foreach (GameObject select in selectionHighlight)
        {
            select.SetActive(false);
            /*Vector3 pushBack = select.transform.position;
            pushBack.z = 0f; 
            select.transform.position = pushBack; */
        }
        thisSelect.SetActive(true);
        /*Vector3 pullForward = thisSelect.transform.position;
        pullForward.z = 0f;
        thisSelect.transform.position = pullForward;*/
    }

    
}
