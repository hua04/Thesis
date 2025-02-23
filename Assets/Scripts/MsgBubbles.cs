using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;

public class MsgBubbles : MonoBehaviour
{
    public GameObject messengerObj;

    public int count;

    public bool start;

    public static IEnumerator coroutine;
    public NpcConvo npcConvo;

    public List<GameObject> sentDialogue;

    public static string[] currentConvo; //Dialogue

    public static bool[] npcTalker;//checks if NPC or player is talking

    public GameObject npcSpeech; //the speech bubbles

    public GameObject playerSpeech;

    public GameObject npcSpawnLocation;

    public GameObject playerSpawnLocation;

    //public TextMeshProUGUI endingtext;


    //public Animator fade;

    public GameObject temp;

    public void Start()
    {
        start = false;
    }

    public void Update()
    {

        if (messengerObj.activeInHierarchy&& !start)
        {
            start = true;
            npcTalker = npcConvo.npcTalker;
            currentConvo = npcConvo.currentConvo;
            StartCoroutine(Conversation(currentConvo, currentConvo.Length, npcTalker));
            start = true;
        }
    }

    public IEnumerator Conversation(string[] convo, int convoLength, bool[] npc) //Start Responses
    {
        currentConvo = convo;
        coroutine = Conversation(convo, convoLength, npc);


        for (int i = count; i < convoLength; i++)
        {
            yield return new WaitForSeconds(3);

            if (npc[i])
            {
                temp = Instantiate(npcSpeech, npcSpawnLocation.transform);
            }
            else if (!npc[i])
            {
                temp = Instantiate(playerSpeech, playerSpawnLocation.transform);
            }

            var inbetween = temp.transform.GetChild(0);
            var text = inbetween.transform.GetChild(0);
            text.GetComponent<TextMeshProUGUI>().text = convo[i];

            foreach (GameObject sentDialogue in sentDialogue)
            {
                sentDialogue.GetComponent<RectTransform>().transform.position += new Vector3(0, 100f, 0);
            }
            sentDialogue.Add(temp);
            count++;
        }

        /* if (count == convoLength && Choice.choiceMade == false)
         {
             choiceScript.ChoiceConvo();
         }
         else if (count == convoLength && Choice.choiceMade == true)
         {
             if (Choice.betterChoice && ClientPick.amberPick)
             {
                 pageSetupScript.feeling.text = "<color=#66ff99>Hopeful</color>";
             }
             else if (Choice.betterChoice && ClientPick.krisPick)
             {
                 pageSetupScript.feeling.text = "<color=#66ff99>Sad</color>";
             }

             yield return new WaitForSeconds(3);
             foreach (GameObject sentDialogue in sentDialogue)
             {
                 sentDialogue.GetComponent<RectTransform>().transform.position += new Vector3(0, 50f, 0);
             }
             endingtext.text = "-" + pageSetupScript.nameText.text.ToString() + " has left the chat-";
             yield return new WaitForSeconds(3);
             fade.SetTrigger("End");

         }*/


    }




   /* public IEnumerator PlayerConversation()
    {

        foreach (GameObject sentDialogue in sentDialogue)
        {
            sentDialogue.GetComponent<RectTransform>().transform.position += new Vector3(0, 100f, 0);
        }
        var temp = Instantiate(playerSpeech, playerSpawnLocation.transform);
        var text = temp.transform.GetChild(0);
        text.GetComponent<TextMeshProUGUI>().text = Typer.typedWord;
        Typer.typedWord = "";
        sentDialogue.Add(temp);
        typerScript.wordOutput.text = "";
        yield return new WaitForSeconds(1);

        StartCoroutine(Conversation(currentConvo, currentConvo.Length, currentResponses));

    }*/


}