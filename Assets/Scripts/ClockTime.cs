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
    public Animator ending;
    public Animator fade;


    public void Start()
    {
        Debug.developerConsoleVisible = true;
        var temp = GameObject.FindGameObjectWithTag("Min");
        minTMP = temp.GetComponent<TextMeshProUGUI>();

        temp = GameObject.FindGameObjectWithTag("Hour");
        hourTMP = temp.GetComponent<TextMeshProUGUI>();
        temp = GameObject.FindGameObjectWithTag("AMPM");
        timeOfDayTMP = temp.GetComponent<TextMeshProUGUI>();
        UpdateTime();
        Debug.LogError("Script on");
    }

    [YarnCommand("addtime")]
    public void UpdateTime()
    {
        Debug.LogError("Function Called");
        min += 30;
        hour = Convert.ToInt32(hourTMP.text);
        Debug.Log(min + ", " + hour);
         if (min == 60)
         {
             hour++;
             min = 00;
         }
        
        Debug.Log(hour + " : " + min);

        string x = min.ToString("D2");
        string y = hour.ToString("D2");

        minTMP.text = x;
        hourTMP.text = y;
        Debug.LogError(hour + ":" + min);
        EventQueue.instance.CheckForEvent(hour, min);

        if (hour == 10)
        {
            fade.SetTrigger("end");
            ending.SetTrigger("end");
        }
        Debug.LogError("Complete");
    }
        

}
