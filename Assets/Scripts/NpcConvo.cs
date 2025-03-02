using UnityEngine;

[CreateAssetMenu(fileName = "NPC", menuName = "ScriptableObjects/NPC")]
public class NpcConvo : ScriptableObject
{
    public int hour;
    public int min;

    public bool[] npcTalker;
    public string[] starterConvo;


    public string choiceOne;
    public string choiceTwo;

    public NpcConvo BranchOne;
    public NpcConvo BranchTwo;

    public bool end;

}
