using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI dialogueText;
    public Button choiceButtonPrefab;
    public Transform buttonContainer;

    [Header("Dialogue do uruchomienia")]
    public Dialogue dialogue;

    private Dialogue currentDialogue;
    private int currentNodeIndex;
    private bool dialogueActive = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !dialogueActive)
        {
            StartDialogue(dialogue);
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if (dialogue == null)
        {
            Debug.LogError("Brak dialogu!");
            return;
        }

        // 🔒 SPRAWDZENIE WYMAGAŃ
        if (!DialogueProgress.AreRequirementsMet(dialogue.requiredDialogues))
        {
            Debug.Log("Nie możesz jeszcze tego dialogu zrobić!");
            return;
        }

        // 🔒 JEŚLI JUŻ ZROBIONY
        if (DialogueProgress.IsCompleted(dialogue.dialogueID))
        {
            Debug.Log("Ten dialog już został ukończony!");
            return;
        }

        currentDialogue = dialogue;
        currentNodeIndex = 0;
        dialogueActive = true;

        ShowNode();
    }

    void ShowNode()
    {
        if (currentDialogue == null || currentDialogue.nodes.Length == 0)
        {
            Debug.LogError("Dialogue pusty!");
            return;
        }

        // usuń stare przyciski
        foreach (Transform child in buttonContainer)
        {
            Destroy(child.gameObject);
        }

        Node node = currentDialogue.nodes[currentNodeIndex];
        dialogueText.text = node.text;

        // 🔚 KONIEC DIALOGU
        if (node.choices == null || node.choices.Length == 0)
        {
            // oznacz jako ukończony
            DialogueProgress.CompleteDialogue(currentDialogue.dialogueID);

            Button btn = Instantiate(choiceButtonPrefab, buttonContainer);
            btn.GetComponentInChildren<TextMeshProUGUI>().text = "Wyjdź";

            RectTransform rt = btn.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(300, rt.sizeDelta.y);

            btn.onClick.AddListener(() =>
            {
                dialogueActive = false;

                PhoneNotification.phoneNotification = true;
                SceneManager.LoadScene("Main");
            });

            return;
        }

        // 🔘 OPCJE WYBORU
        foreach (var choice in node.choices)
        {
            Button btn = Instantiate(choiceButtonPrefab, buttonContainer);

            TextMeshProUGUI btnText = btn.GetComponentInChildren<TextMeshProUGUI>();
            btnText.text = choice.text;

            int nextIndex = choice.nextNodeIndex;

            btn.onClick.AddListener(() =>
            {
                if (nextIndex >= 0 && nextIndex < currentDialogue.nodes.Length)
                {
                    currentNodeIndex = nextIndex;
                    ShowNode();
                }
                else
                {
                    Debug.LogError("Zły nextNodeIndex: " + nextIndex);
                }
            });
        }
    }
}