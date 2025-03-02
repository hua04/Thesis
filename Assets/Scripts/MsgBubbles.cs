using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MsgBubbles : MonoBehaviour
{
    public GameObject messengerObj;

    public int npcCount;

    public int playerCount;

    public bool start;

    public IEnumerator coroutine;

    public NpcConvo npcConvo;

    public List<GameObject> sentDialogue;

    public string[] currentConvo; //Dialogue

    public bool[] npcTalker;//checks if NPC or player is talking

    public GameObject npcSpeech; //the speech bubbles

    public GameObject playerSpeech;

    public GameObject npcSpawnLocation;

    public GameObject playerSpawnLocation;

    public TextMeshProUGUI choiceOne;

    public TextMeshProUGUI choiceTwo;

    public Button buttonOne;

    public Button buttonTwo;

    public Time timeScript;


    //public TextMeshProUGUI endingtext;


    //public Animator fade;

    public GameObject temp;

    public void Start()
    {
        start = false;
        buttonOne.interactable = false;
        buttonTwo.interactable = false;
        Debug.Log("on");
    }

    public void Update()
    {

        if (messengerObj.activeInHierarchy && !start)
        {
            if (npcConvo.min == timeScript.min && npcConvo.hour == timeScript.hour)
            {
                start = true;
                npcTalker = npcConvo.npcTalker;
                currentConvo = npcConvo.starterConvo;
                StartCoroutine(Conversation(currentConvo, currentConvo.Length, npcTalker));

                Debug.Log("started");
            }
           
        }
    }

    public IEnumerator Conversation(string[] convo, int convoLength, bool[] npc) //Start Responses
    {

        Debug.Log("started");
        currentConvo = convo;
        coroutine = Conversation(convo, convoLength, npc);

        for (int i = npcCount; i < convoLength; i++)
        {
            if (npc[i])
            {
                temp = Instantiate(npcSpeech, npcSpawnLocation.transform);
                var inbetween = temp.transform.GetChild(0);
                var text = inbetween.transform.GetChild(0);
                text.GetComponent<TextMeshProUGUI>().text = convo[i];


                yield return new WaitForEndOfFrame();

                sentDialogue.Add(temp);
                foreach (GameObject sentDialogue in sentDialogue)
                {
                    var dist = temp.transform.GetChild(0);
                    float height = dist.GetComponent<RectTransform>().rect.height;
                    RectTransform rt = sentDialogue.GetComponent<RectTransform>();
                    rt.anchoredPosition += new Vector2(0, height);
                }
                npcCount++;
            }
            else if (!npc[i])
            {
                choiceOne.text = npcConvo.choiceOne;
                choiceTwo.text = npcConvo.choiceTwo;
                buttonOne.interactable = true;
                buttonTwo.interactable = true;

            }


            yield return new WaitForSeconds(3);
        }

    }

    public void ChoiceButton(int choice)
    {
        StartCoroutine(Response(choice));
    }

    public IEnumerator Response(int choice)
    {
        NpcConvo nextConvo = npcConvo.BranchOne;
        temp = Instantiate(playerSpeech, playerSpawnLocation.transform);
        var inbetween = temp.transform.GetChild(0);
        var text = inbetween.transform.GetChild(0);

        if (choice == 1)
        {
            text.GetComponent<TextMeshProUGUI>().text = npcConvo.choiceOne;
            nextConvo = npcConvo.BranchOne;

        }
        else if (choice == 2)
        {
            text.GetComponent<TextMeshProUGUI>().text = npcConvo.choiceTwo;
            nextConvo = npcConvo.BranchTwo;
        }
        yield return new WaitForEndOfFrame();
        var dist = temp.transform.GetChild(0);
        float height = dist.GetComponent<RectTransform>().rect.height;
        Debug.Log(height);
        sentDialogue.Add(temp);
        foreach (GameObject sentDialogue in sentDialogue)
        {
            RectTransform rt = sentDialogue.GetComponent<RectTransform>();
            rt.anchoredPosition += new Vector2(0, height);
        }

        choiceOne.text = "";
        choiceTwo.text = "";
        buttonOne.interactable = false;
        buttonTwo.interactable = false;

        npcCount = 0;
        yield return new WaitForSeconds(3);
        npcConvo = nextConvo;


        StartCoroutine(Conversation(npcConvo.starterConvo, npcConvo.starterConvo.Length, npcConvo.npcTalker));



    }
}