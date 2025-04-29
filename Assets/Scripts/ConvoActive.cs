using UnityEngine;

public class ConvoActive : MonoBehaviour
{
    public int convoCount;
    public GameObject convos;
    public GameObject[] allConvos;
    public GameObject thisConvo;
    public GameObject[] selectionHighlight;
    public GameObject thisSelect;
   // public EventQueue eventQueue;
   // public Location thisLocation;
    public void Awake()
    {
        convoCount = convos.transform.childCount;
        allConvos = GameObject.FindGameObjectsWithTag("Convo");
        selectionHighlight = GameObject.FindGameObjectsWithTag("Select");
    }
    public void Start()
    {
        if (thisConvo.transform.name != "BossConvo")
        {
            thisConvo.transform.Find("Dialogue Canvas").gameObject.SetActive(false);
        }


        if (thisSelect.transform.parent.name != "BossSelect")
        {
            thisSelect.SetActive(false);
        }
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


       // eventQueue.CheckForLocation(thisLocation);


    }

}
