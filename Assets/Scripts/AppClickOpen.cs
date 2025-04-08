using System.Collections.Generic;
using UnityEngine;

public class AppClickOpen : MonoBehaviour
{
    public GameObject FileToOpen;
    public static List<GameObject> openFiles = new List<GameObject>();
    private static List<GameObject> starterFiles = new List<GameObject> ();
    public void Awake()
    {
        if (FileToOpen.name!= "GameApp")
        {
            FileToOpen.SetActive(false);
        }
        else
        {
            openFiles.Add(FileToOpen);
        }

      for(int i = 0; i < openFiles.Count - 1; i++) //checking for null files from last run
        {
            var file = openFiles[i];
            if(file == null)
            {
                openFiles.Remove(file);
            }
        }
        
    }

    public void OpenFile()
    {
        if (openFiles.Contains(FileToOpen))
        {
            //if file is already open
            FileToOpen.SetActive(true);
            //find file and move it to the front
            int lastPosition = openFiles.IndexOf(FileToOpen);
            openFiles.RemoveAt(lastPosition);
            openFiles.Add(FileToOpen);
        }
        else
        {
            //if file isn't open
            FileToOpen.SetActive(true);
            //open file and move it to the front
            openFiles.Add(FileToOpen);
        }
        //update file order
        for (int index = 0; index < openFiles.Count; index++)
        {
            GameObject current= openFiles[index];
            Canvas myCanvas = current.GetComponent<Canvas>();
            myCanvas.sortingOrder = index;
            Debug.Log(openFiles);
        }
    }
}
