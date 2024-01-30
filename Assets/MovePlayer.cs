using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce = 5f;
    public float initialForce = 1f; // Kezdeti erõ

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Fix Velocity
        Vector2 velocity = Vector2.right * 2;
        rb.velocity = velocity;
        rb.AddForce(Vector2.right * initialForce, ForceMode2D.Impulse);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    void Jump()
    {
        // Fix Velocity Change
        Vector2 velocityChange = Vector2.up * jumpForce;
        rb.velocity = velocityChange;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().DecreaseLives();
        }
        else if (other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
        else if (other.gameObject.tag == "Blackline")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }


}
