using UnityEngine;

[CreateAssetMenu(fileName = "NPC", menuName = "ScriptableObjects/NPC")]
public class NpcConvo : ScriptableObject
{

    public bool[] npcTalker;
    public string[] currentConvo;


    public string choiceOne;
    public string choiceTwo;

}
