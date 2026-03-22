using UnityEngine;

public class ChangeCollision : MonoBehaviour
{
    public GameObject player;

    private SpriteRenderer playerRenderer;

    private void Start()
    {
        playerRenderer = player.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerRenderer.sortingOrder = 6;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            playerRenderer.sortingOrder = 2;
        }
    }
}