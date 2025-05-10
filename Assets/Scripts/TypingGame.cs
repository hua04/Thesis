using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypingGame : MonoBehaviour
{
    public TextMeshProUGUI wordOutput;
    public GameObject cursor;
    public float lastY;
    public float currentY;
    public ScrollRect scroll;
    public ClockTime timeScript;
    public Vector3 cursorLocation;


    private string remainingWord;
    public string typedWord;
    [TextArea(3, 7)]
    public string currentWord = "";

    public GameObject desktopApp;
    public GameObject gameApp;
    public Notifications notifications;
    public TypingAppManager typingAppManager;

    public EventQueue eventQueue;
    public bool notIntro;


    void Start()
    {

        SetCurrentWord();
        currentY = cursor.transform.position.y;
    }

    void SetCurrentWord()
    {
        SetRemainingWord(currentWord);
    }

    void SetRemainingWord(string newString)
    {
        remainingWord = newString;
        wordOutput.text = "<b>" + typedWord + "</b>";


    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();

    }

    void CheckInput()
    {
        if (Input.anyKeyDown & gameApp.activeInHierarchy)
        {
            string keysPressed = Input.inputString;
            if (keysPressed.Length == 1)
            {

                EnterLetter(); //detects letter press
                EnterLetter();
                EnterLetter();
            }
        }
    }

    void EnterLetter()
    {

        RemoveLetter();
        UpdateCursorPosition();


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


    private void UpdateCursorPosition()
    {
        lastY = currentY;
        // Make sure this text mesh is actually updated before we do the next calculations
        wordOutput.ForceMeshUpdate();
        TMP_TextInfo textInfo = wordOutput.textInfo;
        int characterPosition = Mathf.Max(0, textInfo.characterCount - 1);
        TMP_CharacterInfo lastChar = textInfo.characterInfo[characterPosition];
        var localPosition = new Vector2(
            lastChar.topRight.x + 10, // arbitrary x offset
            (lastChar.baseLine + 13) // arbitrary height offset
        );

        var anchoredPosition = localPosition;

        cursor.transform.localPosition = anchoredPosition;
        cursor.gameObject.SetActive(true);
        currentY = cursor.transform.position.y;
        Debug.Log(currentY + "," + lastY);
        if (currentY != lastY && currentY <= 300f)
        {
            scroll.verticalNormalizedPosition -= 0.01f;
        }
    }
    bool IsComplete()
    {

        return remainingWord.Length == 0;
    }

    public void SubmitPress()
    {
        if (IsComplete())
        {

            if (notIntro)
            {
                eventQueue.SetPath("work");
            }
            typingAppManager.RemoveFile(desktopApp);
            Destroy(desktopApp);
            int lastPosition = AppClickOpen.openFiles.IndexOf(gameApp);
            AppClickOpen.openFiles.RemoveAt(lastPosition);
            Destroy(gameApp);
            timeScript.UpdateTime();
            notifications.NotifOn();
            Destroy(gameObject);
        }
    }
}
