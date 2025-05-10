using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using Yarn.Unity;

public class EventQueue : MonoBehaviour
{
    public List<EventTrigger> EventTriggers;
    public List<EventTrigger> AvailableEvents;
    public static EventQueue instance;
    public List<GameObject> activeConvo;
    public List<GameObject> indicators;
    public bool worked;
    public bool played;
    public Animator ending;
    public Animator fade;
    public bool[] opened;
    public DialogueRunner[] runners;
    void Start()
    {
        worked = false;
        played = false;
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
        AvailableEvents.Clear();
        for (int i = 0; i < opened.Length; i++)
        {
            opened[i] = false;
        }

        for (int i = 0; i < EventTriggers.Count; i++)
        {
            var currentEvent = EventTriggers[i];
            if (currentEvent.min == min && currentEvent.hour == hour)
            {
                AvailableEvents.Add(currentEvent);

            }

        }
        if (hour == 9 && min == 30)
        {
            List<EventTrigger> endingEvents = new List<EventTrigger>();
            if (worked && played)
            {
                foreach (EventTrigger possibleEvent in AvailableEvents)
                {
                    if (possibleEvent.work && possibleEvent.play)
                    {
                        endingEvents.Add(possibleEvent);
                        Debug.Log("worked and played");
                    }
                }
            }
            else if (worked && !played)
            {
                foreach (EventTrigger possibleEvent in AvailableEvents)
                {
                    if (possibleEvent.work && !possibleEvent.play)
                    {
                        endingEvents.Add(possibleEvent);
                        Debug.Log("worked only");
                    }
                }
            }
            else if (!worked && played)
            {
                foreach (EventTrigger possibleEvent in AvailableEvents)
                {
                    if (!possibleEvent.work && possibleEvent.play)
                    {
                        endingEvents.Add(possibleEvent);
                        Debug.Log("played only");
                    }
                }
            }
            AvailableEvents.Clear();
            AvailableEvents = endingEvents;

        }

    }

    public void ConvoIndicators()
    {

        foreach (Location loc in (Location[])Enum.GetValues(typeof(Location)))
        {
            if (loc != Location.gameWindow && loc != Location.none)
            {
                indicators[(int)loc - 1].SetActive(false);

            }
        }
        foreach (EventTrigger convo in AvailableEvents)
        {
            if (convo.eventLocation != Location.gameWindow && convo.eventLocation != Location.none)
            {
                convo.highlight.SetActive(true);

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
        ConvoIndicators();
        current.dialogueRunner.StartDialogue(current.nodeName);
        // AvailableEvents.Remove(current);
    }

    [YarnCommand("remove")]
    public void RemoveEvent(string title)
    {
        foreach (EventTrigger convo in AvailableEvents)
        {
            if (convo.scriptTitle == title)
            {
                AvailableEvents.Remove(convo);
                break;
            }
        }
        ConvoIndicators();

    }


    [YarnCommand("setpath")]
    public void SetPath(string path)
    {
        if (path == "work")
        {
            worked = true;
        }
        else if (path == "play")
        {
            played = true;
        }
    }
    [YarnCommand("end")]
    public void Ending()
    {
        fade.SetTrigger("end");
        ending.SetTrigger("end");

    }

    public void OpenCheck(int location)
    {
        if (!opened[location - 1])
        {
            runners[location - 1].Stop();
            SendLocation(location);
            opened[location - 1] = true;
        }

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
    public GameObject highlight;
    public bool play;
    public bool work;

}

[System.Serializable]
public enum Location
{
    none, bossChat, friendChat, coworkerOneChat, onlineFriendChat, coworkerTwoChat, gameWindow
}
