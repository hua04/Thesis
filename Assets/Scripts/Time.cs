using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Time : MonoBehaviour
{
    public static int min;
    public static int hour;
    public TMP_Text minTMP;
    public TMP_Text hourTMP;
    public TMP_Text timeOfDayTMP;
    public AudioSource beep;
    public static int gameClick;
    public void ClickGame()
    {
        Debug.Log("click");
        gameClick++;
        beep.Play();
        min = Convert.ToInt32(minTMP.text);
        hour = Convert.ToInt32(hourTMP.text);
        Debug.Log(min + ", " + hour);
        if (min == 30)
        {
            hour++;
            min = 00;
        }
        else if (min == 00)
        {
            min = 30;
        }
        if (hour == 13)
        {
            hour = 1;
            timeOfDayTMP.text = "PM";
        }


        string x = min.ToString("D2");
        string y = hour.ToString("D2");

        minTMP.text = x;
        hourTMP.text = y;
    }
}
