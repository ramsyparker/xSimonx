using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour
{
    public Transform PointA;
    public Transform PointB;
    public float speed = 2f;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask whatIsGround;

    public GameObject gameOverPanel; // ✅ Panel Game Over

    private Rigidbody2D rb;
    private Animator animator;
    private bool movingToB = false;
    private bool isGrounded;
    private bool isWaiting = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        Debug.Log("Start Enemy. Position: " + transform.position + " | PointA: " + PointA.position + " | PointB: " + PointB.position);

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        FlipSprite();
    }

    void Update()
    {
        CheckGround();

        if (!isGrounded || isWaiting)
        {
            rb.velocity = Vector2.zero;
            if (animator != null) animator.SetBool("isWalking", false);
            return;
        }

        Patrol();
    }

    void CheckGround()
    {
        Collider2D groundCollider = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        isGrounded = groundCollider != null;
    }

    void Patrol()
    {
        Transform target = movingToB ? PointB : PointA;
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);

        if (animator != null) animator.SetBool("isWalking", true);

        float xDistance = Mathf.Abs(transform.position.x - target.position.x);
        if (xDistance < 0.2f)
        {
            Debug.Log("Reached target: " + target.name);
            StartCoroutine(SwitchDirectionWithDelay(0.5f));
        }
    }

    IEnumerator SwitchDirectionWithDelay(float delay)
    {
        isWaiting = true;
        rb.velocity = Vector2.zero;

        if (animator != null)
            animator.SetBool("isWalking", false);

        yield return new WaitForSeconds(delay);

        movingToB = !movingToB;
        FlipSprite();

        Debug.Log("Switching direction. Now moving to: " + (movingToB ? "PointB" : "PointA"));

        isWaiting = false;
    }

    void FlipSprite()
    {
        float scaleX = Mathf.Abs(transform.localScale.x);
        float direction = movingToB ? 1f : -1f;
        transform.localScale = new Vector3(direction * scaleX, transform.localScale.y, transform.localScale.z);
    }

    // ✅ Tambahkan ini agar musuh bisa menyebabkan Game Over
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Enemy hit player. Game Over.");
            if (gameOverPanel != null)
                gameOverPanel.SetActive(true);

            Time.timeScale = 0f;
        }
    }
}
