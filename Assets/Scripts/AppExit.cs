using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AppExit : MonoBehaviour
{
    public GameObject FileToOpen;
    public void CloseApp()
    {
        //find file and move it to the front
        int lastPosition = AppClickOpen.openFiles.IndexOf(FileToOpen);
        AppClickOpen.openFiles.RemoveAt(lastPosition);
        AppClickOpen.openFiles.Add(FileToOpen);

        //update file order

        for (int index = 0; index < AppClickOpen.openFiles.Count; index++)
        {
            GameObject current = AppClickOpen.openFiles[index];
            Canvas myCanvas = current.GetComponent<Canvas>();
            myCanvas.sortingOrder = index;
            Debug.Log(AppClickOpen.openFiles);
        }

        //close file
        FileToOpen.SetActive(false);

      


    }
}
