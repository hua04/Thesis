using UnityEngine;

public class GameandDialogueConnect : MonoBehaviour
{
    public GameObject gameApp;
    public GameObject dialogueBox;

    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        if (AppClickOpen.openFiles.Count > 0)
        {
            if (gameApp == AppClickOpen.openFiles[AppClickOpen.openFiles.Count - 1] && gameApp.activeInHierarchy)
            {
                dialogueBox.SetActive(true);
            }
            else
            {
                dialogueBox.SetActive(false);
            }
        }
        else
        {
            dialogueBox.SetActive(false);
        }
    }
}
