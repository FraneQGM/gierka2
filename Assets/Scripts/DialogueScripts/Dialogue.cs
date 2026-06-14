using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue/New Dialogue")]
public class Dialogue : ScriptableObject
{
    public string dialogueID;
    public string[] requiredDialogues;

    public Node[] nodes;
}

[System.Serializable]
public class Node
{
    [TextArea]
    public string text;
}