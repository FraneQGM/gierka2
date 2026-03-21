using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public int health = 100;

    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;

    public float pixelsPerUnit = 32f;

    private Vector3 originalScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        // INPUT
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = movement.normalized;

        // ANIMATOR (pasuje do moveX / moveY / isMoving)
        animator.SetFloat("moveX", movement.x);
        animator.SetFloat("moveY", movement.y);
        animator.SetBool("isMoving", movement != Vector2.zero);

        // FLIP TYLKO W POZIOMIE
        if (movement.x < 0)
        {
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
        }
        else if (movement.x > 0)
        {
            transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
        }
    }

    void FixedUpdate()
    {
        float unitsPerPixel = 1f / pixelsPerUnit;

        Vector2 newPos = rb.position + movement * speed * Time.fixedDeltaTime;

        // PIXEL SNAP
        newPos.x = Mathf.Round(newPos.x / unitsPerPixel) * unitsPerPixel;
        newPos.y = Mathf.Round(newPos.y / unitsPerPixel) * unitsPerPixel;

        rb.MovePosition(newPos);
    }
}