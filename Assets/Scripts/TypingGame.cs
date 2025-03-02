using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypingGame : MonoBehaviour
{
    public TextMeshProUGUI wordOutput;
    //public TextMeshProUGUI timer;
    public GameObject cursor;
    public int cursorGap;
    public int spaceDown;
    public int startSpace;
    public int rightLimit;
    public ScrollRect scroll;


    private string remainingWord;
    private string typedWord;
    public string currentWord = "";
    // public float timeRemaining = 60;

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
        
        if (cursor.transform.position.x > rightLimit && remainingWord[0]==' ')
        {
            Vector3 moveDown = cursor.transform.position + new Vector3(0, spaceDown, 0);
            moveDown.x = startSpace;
            cursor.transform.position = moveDown;
            scroll.verticalNormalizedPosition -= 0.03f;
        }
        else
        {
            Vector3 newPosition = cursor.transform.position + new Vector3(cursorGap, 0, 0);
            cursor.transform.position = newPosition;
        }
    }

    bool IsComplete()
    {

        return remainingWord.Length == 0;
    }
}
