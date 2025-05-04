using UnityEngine;
using Yarn.Unity;

public class ConvoActive : MonoBehaviour
{
    public int convoCount;
    public GameObject convos;
    public GameObject[] allConvos;
    public GameObject thisConvo;
    public GameObject[] selectionHighlight;
    public GameObject thisSelect;
    public GameObject thisInactive;
    public bool convoOn=false;
   // public Location thisLocation;
    public void Awake()
    {
        convoCount = convos.transform.childCount;
        allConvos = GameObject.FindGameObjectsWithTag("Convo");
        selectionHighlight = GameObject.FindGameObjectsWithTag("Select");
    }
    public void Start()
    {
        /*if (thisConvo.transform.name != "BossConvo")
        {
            thisConvo.transform.Find("Dialogue Canvas").gameObject.SetActive(false);
        }


        if (thisSelect.transform.parent.name != "BossSelect")
        {
            thisSelect.SetActive(false);
        }*/
        thisConvo.transform.Find("Dialogue Canvas").gameObject.SetActive(false);
        thisSelect.SetActive(false);
    }
    public void ConvoSelected()
    {
        foreach (GameObject convo in allConvos)
        {
            convo.transform.Find("Dialogue Canvas").gameObject.SetActive(false);

        }
        thisConvo.transform.Find("Dialogue Canvas").gameObject.SetActive(true);
        foreach (GameObject select in selectionHighlight)
        {
            select.SetActive(false);


        }
        thisSelect.SetActive(true);

        if (!convoOn)
        {
            thisInactive.SetActive(true);
        }
        else
        {
            thisInactive.SetActive(false);
        }
       


        // eventQueue.CheckForLocation(thisLocation);


    }

    [YarnCommand("active")]
    public void activeScreen(bool off)
    {
        thisInactive.SetActive(off);
        convoOn = !off;

    }

}
