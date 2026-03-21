using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue/New Dialogue")]
public class Dialogue : ScriptableObject
{
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