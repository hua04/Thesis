using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class AppClickOpen : MonoBehaviour
{
    public GameObject FileToOpen;
    public static List<GameObject> openFiles = new List<GameObject>();

    public void Start()
    {
        FileToOpen.SetActive(false);
    }

    public void OpenFile()
    {
        if (openFiles.Contains(FileToOpen))
        {
            FileToOpen.SetActive(true);
            int lastPosition = openFiles.IndexOf(FileToOpen);
            openFiles.RemoveAt(lastPosition);
            openFiles.Add(FileToOpen);
        }
        else
        {
            FileToOpen.SetActive(true);
            openFiles.Add(FileToOpen);
        }
        for (int index = 0; index < openFiles.Count; index++)
        {
            GameObject current= openFiles[index];
            Canvas myCanvas = current.GetComponent<Canvas>();
            myCanvas.sortingOrder = index;
        }
    }
}
