using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue/New Dialogue")]
public class Dialogue : ScriptableObject
{
    [Header("ID dialogu")]
    public string dialogueID; // np. "dialogue1"

    [Header("Wymagane dialogi (blokada)")]
    public string[] requiredDialogues;

    public Node[] nodes;
}

[System.Serializable]
public class Node
{
    [TextArea]
    public string text;

    public Choice[] choices;
}

[System.Serializable]
public class Choice
{
    public string text;
    public int nextNodeIndex;
}