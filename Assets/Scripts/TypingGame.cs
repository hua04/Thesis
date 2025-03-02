using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypingGame : MonoBehaviour
{
    public TextMeshProUGUI wordOutput;
    //public TextMeshProUGUI timer;
    public GameObject cursor;
    public int cursorGap;
    public float spaceDown;
    public int startSpace;
    public int rightLimit;
    public ScrollRect scroll;
    public Time timeScript;


    private string remainingWord;
    private string typedWord;
    public string currentWord = "";
    // public float timeRemaining = 60;

    public GameObject desktopApp;
    public GameObject gameApp;

    void Start()
    {
        SetCurrentWord();
    }

    void SetCurrentWord()
    {
        SetRemainingWord(currentWord);
    }

    void SetRemainingWord(string newString)
    {
        remainingWord = newString;
        wordOutput.text = "<b>" + typedWord + "</b>" + "<color=white>" + remainingWord + "</color>";//Creates color difference between word already typed and not yet typed
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();

    }

    void CheckInput()
    {
        if (Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;
            if (keysPressed.Length == 1)
            {

                MoveCursor();
                EnterLetter(keysPressed); //detects letter press
                
            }
        }
    }

    void EnterLetter(string typedLetter)
    {

        RemoveLetter();
        

        if (IsComplete()) //checks if player has completed the typed sentances
        {
            Debug.Log("Done");


        }


    }

    void RemoveLetter()
    {
        char temp = remainingWord[0];
        string newString = remainingWord.Remove(0, 1);
        typedWord += temp;
        SetRemainingWord(newString);
    }

   void MoveCursor()
    {
        if (!IsComplete())
        {
            if (cursor.transform.localPosition.x > rightLimit && remainingWord[0] == ' ')
            {
                Vector3 moveDown = cursor.transform.localPosition + new Vector3(0, spaceDown, 0);
                moveDown.x = startSpace;
                cursor.transform.localPosition = moveDown;
                scroll.verticalNormalizedPosition -= 0.03f;
            }
            else
            {
                Vector3 newPosition = cursor.transform.localPosition + new Vector3(cursorGap, 0, 0);
                cursor.transform.localPosition = newPosition;
            }
        }
    }

    bool IsComplete()
    {

        return remainingWord.Length == 0;
    }

    public void SubmitPress()
    {
        //if (IsComplete())
        //{
            Destroy(desktopApp);
            int lastPosition = AppClickOpen.openFiles.IndexOf(gameApp);
            AppClickOpen.openFiles.RemoveAt(lastPosition);
            Destroy(gameApp);
            
            timeScript.UpdateTime();

       // }
    }
}
