using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Unity;

public class EventQueue : MonoBehaviour
{
    public List<EventTrigger> EventTriggers;
    public List<EventTrigger> AvailableEvents;
    public static EventQueue instance;
    public List<GameObject> activeConvo;
    void Start()
    {
        AvailableEvents = new List<EventTrigger>();
        if (instance == null)
        {
            instance = this;
        }
        if (instance != this)
        {
            Destroy(gameObject);
        }
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckForEvent(int hour, int min) //Checking if event can be triggered at this time
    {
        for (int i = 0; i < EventTriggers.Count; i++)
        {
            var currentEvent = EventTriggers[i];
            if (currentEvent.min == min && currentEvent.hour == hour)
            {
                AvailableEvents.Add(currentEvent);
            }
        }
    }

//  none, bossChat, friendChat, coworkerOneChat, coworkerTwoChat, onlineFriendChat, gameWindow (6)
    // 0, 1, 2, 3 ,4 , and so on
    public void SendLocation(int locationNum)
    {
        CheckForLocation((Location)locationNum);
    }

    public void CheckForLocation(Location current) //Checking available events at this location
    {
        for (int i = 0; i < AvailableEvents.Count; i++)
        {

            if (AvailableEvents[i].eventLocation == current)
            {
               
                RunEvent(AvailableEvents[i]);
                return;
            }
        }
    }

    public void RunEvent(EventTrigger current)
    {
        Debug.Log(current.nodeName);
        current.dialogueRunner.StartDialogue(current.nodeName);
        AvailableEvents.Remove(current);
    }
}

[System.Serializable]
public class EventTrigger
{
    public string scriptTitle;
    public string nodeName;
    public int hour;
    public int min;
    public Location eventLocation;
    public TextAsset script;
    public DialogueRunner dialogueRunner; 

}

[System.Serializable]
public enum Location
{
    none, bossChat, friendChat, coworkerOneChat, onlineFriendChat,coworkerTwoChat,  gameWindow
}
