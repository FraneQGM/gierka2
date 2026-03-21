using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public string sceneToLoad;
    private bool playerInRange = false;

    public static Vector3 lastPosition;

    private GameObject player;

    public GameObject clickButtonUI;

    private void Start()
    {
        if (DialogueManager.dialogueCompleted)
        {
            Debug.Log("Scena dialogowa zablokowana.");
            return;
        }
        if (clickButtonUI != null)
            clickButtonUI.SetActive(false);
    }

    private void Update()
    {
        // ❗ BLOKADA INTERAKCJI
        if (DialogueManager.dialogueCompleted)
        {
            if (clickButtonUI != null)
                clickButtonUI.SetActive(false);

            return;
        }

        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (player != null)
            {
                lastPosition = player.transform.position;
            }

            SceneManager.LoadScene(sceneToLoad);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (DialogueManager.dialogueCompleted)
            return; // ❗ blokujemy całkowicie wejście

        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            player = other.gameObject;

            if (clickButtonUI != null)
                clickButtonUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            player = null;

            if (clickButtonUI != null)
                clickButtonUI.SetActive(false);
        }
    }
}