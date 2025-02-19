using System;
using TMPro;
using UnityEngine;

public class TimeEnd : MonoBehaviour
{
    public GameClick TimeScript;
    public GameObject end;
    public TMP_Text work;
    public TMP_Text play;
    public TMP_Text summary;
    public string timeOfDay;
    public bool doneAlready;

    public void Start()
    {
        end.SetActive(false);
        doneAlready = false;
    }
    void Update()
    {
        TimeScript.min = Convert.ToInt32(TimeScript.minTMP.text);
        TimeScript.hour = Convert.ToInt32(TimeScript.hourTMP.text);
        timeOfDay = TimeScript.timeOfDayTMP.text;
        if (TimeScript.hour == 06 && timeOfDay == "PM" && !doneAlready)
        {
            work.text += WorkClick.workClick.ToString();
            play.text += GameClick.gameClick.ToString();

            var temp = GameClick.gameClick - WorkClick.workClick;
            if (temp >= -2 && temp <= 2)
            {
                summary.text = "Great balance!";
            }
            else if (WorkClick.workClick > GameClick.gameClick)
            {
                summary.text = "Whoa there workaholic, take a break!";
            }
            else if (WorkClick.workClick < GameClick.gameClick)
            {
                summary.text = "DO YOUR WORK!!! LOCK IN!!!!!";
            }

            end.SetActive(true);
            doneAlready = true;

        }

    }
}
