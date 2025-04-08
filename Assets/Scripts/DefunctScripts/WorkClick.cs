using System;
using TMPro;
using UnityEngine;

public class WorkClick : MonoBehaviour
{
    public int min;
    public int hour;
    public TMP_Text minTMP;
    public TMP_Text hourTMP;
    public TMP_Text timeOfDayTMP;
    public GameObject canvas;
    public GameObject icon;
    public GameObject FileToOpen;
    public AudioSource beep;
    public static int filesClosed;
    public static int workClick;

    public void Start()
    {
    }
  
    public void ClickWork()
    {
        Debug.Log("click");
        workClick++;
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
            timeOfDayTMP.text = "PM";
            hour = 1;
        }


        string x = min.ToString("D2");
        string y = hour.ToString("D2");

        minTMP.text = x;
        hourTMP.text = y;

        //Remove file from list
        int lastPosition = AppClickOpen.openFiles.IndexOf(FileToOpen);
        AppClickOpen.openFiles.RemoveAt(lastPosition);


        //update file order

        for (int index = 0; index < AppClickOpen.openFiles.Count; index++)
        {
            GameObject current = AppClickOpen.openFiles[index];
            Canvas myCanvas = current.GetComponent<Canvas>();
            myCanvas.sortingOrder = index;
            Debug.Log(AppClickOpen.openFiles);
        }

        icon.SetActive(false);
        canvas.SetActive(false);
        filesClosed++;
        Debug.Log(filesClosed);

    }
}
