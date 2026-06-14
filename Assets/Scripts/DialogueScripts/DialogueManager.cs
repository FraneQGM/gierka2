using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public Dialogue dialogue;

    private Dialogue currentDialogue;
    private int currentNodeIndex;
    private bool dialogueActive;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!dialogueActive)
            {
                StartDialogue(dialogue);
            }
            else
            {
                NextNode();
            }
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if (dialogue == null)
            return;

        if (!DialogueProgress.AreRequirementsMet(dialogue.requiredDialogues))
            return;

        if (DialogueProgress.IsCompleted(dialogue.dialogueID))
            return;

        currentDialogue = dialogue;
        currentNodeIndex = 0;
        dialogueActive = true;

        ShowNode();
    }

    void ShowNode()
    {
        dialogueText.text = currentDialogue.nodes[currentNodeIndex].text;
    }

    void NextNode()
    {
        currentNodeIndex++;

        if (currentNodeIndex >= currentDialogue.nodes.Length)
        {
            EndDialogue();
            return;
        }

        ShowNode();
    }

    void EndDialogue()
    {
        DialogueProgress.CompleteDialogue(currentDialogue.dialogueID);

        dialogueActive = false;

        SceneManager.LoadScene("Main");
    }
}