using UnityEngine;

public class EnterBuilding : MonoBehaviour
{
    public GameObject player;
    public Transform WhereTeleport;
    public GameObject clickButtonUI;

    private bool isPlayerInside = false;

    private void Start()
    {
        clickButtonUI.SetActive(false); // ukryj na starcie (na wszelki wypadek)
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInside = true;
            clickButtonUI.SetActive(true); // pokaż UI
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInside = false;
            clickButtonUI.SetActive(false); // ukryj UI
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerInside)
        {
            player.transform.position = WhereTeleport.position;
            clickButtonUI.SetActive(false); // opcjonalnie: ukryj po wejściu
        }
    }
}