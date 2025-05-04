using System;
using TMPro;
using UnityEngine;
using Yarn.Unity;

public class ClockTime : MonoBehaviour
{
    public int min;
    public int hour;
    public TMP_Text minTMP;
    public TMP_Text hourTMP;
    public TMP_Text timeOfDayTMP;
    public int gameClick;
    public MsgBubbles[] msgScript;


    public void Start()
    {
        var temp = GameObject.FindGameObjectWithTag("Min");
        minTMP = temp.GetComponent<TextMeshProUGUI>();

        temp = GameObject.FindGameObjectWithTag("Hour");
        hourTMP = temp.GetComponent<TextMeshProUGUI>();
        temp = GameObject.FindGameObjectWithTag("AMPM");
        timeOfDayTMP = temp.GetComponent<TextMeshProUGUI>();
        UpdateTime(0);
    }

    [YarnCommand("timepass")]
    public void UpdateTime(int time)
    {
        min += time;
        hour = Convert.ToInt32(hourTMP.text);
        Debug.Log(min + ", " + hour);
         if (min == 60)
         {
             hour++;
             min = 00;
         }
         /*if (hour == 13)
         {
             hour = 1;
             
         }*/
        Debug.Log(hour + " : " + min);

        string x = min.ToString("D2");
        string y = hour.ToString("D2");

        minTMP.text = x;
        hourTMP.text = y;

        /*foreach (MsgBubbles bubble in msgScript)
        {

            bubble.start = false;
        }*/

        EventQueue.instance.CheckForEvent(hour, min);
    }
        

}
