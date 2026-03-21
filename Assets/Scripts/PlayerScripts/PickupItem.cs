using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public GameObject clickButtonUI;
    public GameObject itemToPickup;
    public GameObject itemInUI;

    private bool playerInRange = false;

    void Start()
    {
        // 👉 przy starcie sprawdź czy już mamy item
        if (GameData.hasItem)
        {
            itemToPickup.SetActive(false);

            if (itemInUI != null)
                itemInUI.SetActive(true);
        }
        else
        {
            if (itemInUI != null)
                itemInUI.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            GameData.hasItem = true; // 🔥 ZAPIS

            itemToPickup.SetActive(false);

            if (clickButtonUI != null)
                clickButtonUI.SetActive(false);

            if (itemInUI != null)
                itemInUI.SetActive(true);

            Debug.Log("Przedmiot został podniesiony!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            if (clickButtonUI != null && !GameData.hasItem)
                clickButtonUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            if (clickButtonUI != null)
                clickButtonUI.SetActive(false);
        }
    }
}