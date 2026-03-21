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

    public Dialogue Dialogue;

    private Dialogue currentDialogue;
    private int currentNodeIndex;
    private bool dialogueActive = false;

    // 🔒 GLOBALNA BLOKADA DIALOGU
    public static bool dialogueCompleted = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !dialogueActive && !dialogueCompleted)
        {
            StartDialogue(Dialogue);
            dialogueActive = true;
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        // ❗ BLOKADA
        if (dialogueCompleted)
        {
            Debug.Log("Dialog został już ukończony – zablokowany.");
            return;
        }

        currentDialogue = dialogue;
        currentNodeIndex = 0;
        ShowNode();
    }

    void ShowNode()
    {
        if (currentDialogue == null)
        {
            Debug.LogError("Brak dialogue!");
            return;
        }

        if (currentDialogue.nodes == null || currentDialogue.nodes.Length == 0)
        {
            Debug.LogError("Dialogue nie ma node'ów!");
            return;
        }

        if (currentNodeIndex < 0 || currentNodeIndex >= currentDialogue.nodes.Length)
        {
            Debug.LogError("Zły index node: " + currentNodeIndex);
            return;
        }

        // usuń stare przyciski
        foreach (Transform child in buttonContainer)
        {
            Destroy(child.gameObject);
        }

        Node node = currentDialogue.nodes[currentNodeIndex];

        dialogueText.text = node.text;

        // ❗ KONIEC DIALOGU
        if (node.choices == null || node.choices.Length == 0)
        {
            // oznacz jako zakończony
            dialogueCompleted = true;

            Button btn = Instantiate(choiceButtonPrefab, buttonContainer);
            btn.GetComponentInChildren<TextMeshProUGUI>().text = "Wyjdź";

            RectTransform rt = btn.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(300, rt.sizeDelta.y);

            btn.onClick.AddListener(() =>
            {
                PhoneNotification.phoneNotification = true;
                SceneManager.LoadScene("Main");
            });

            return;
        }

        // NORMALNE OPCJE
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
                    Debug.LogError("Niepoprawny nextNodeIndex: " + nextIndex);
                }
            });
        }
    }
}