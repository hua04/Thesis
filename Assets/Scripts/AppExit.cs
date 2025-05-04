using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AppExit : MonoBehaviour
{
    public GameObject FileToOpen;
    //public GameObject popup;
    public void CloseApp()
    {
       
        int lastPosition = AppClickOpen.openFiles.IndexOf(FileToOpen);
        AppClickOpen.openFiles.RemoveAt(lastPosition);
   

        //Remove file from list

        for (int index = 0; index < AppClickOpen.openFiles.Count; index++)
        {
            GameObject current = AppClickOpen.openFiles[index];
            Canvas myCanvas = current.GetComponent<Canvas>();
            myCanvas.sortingOrder = index;
            Debug.Log(AppClickOpen.openFiles);
        }

        //close file
        FileToOpen.SetActive(false);
        /*if (popup!=null)
        {
            popup.SetActive(false);
        }*/

      


    }
}
