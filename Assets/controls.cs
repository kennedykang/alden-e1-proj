using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float movex;
    float movey;
    int score;
    [SerializeField] float speed = 5f;
    Rigidbody2D rb;
    [SerializeField] float jumpheight = 1f;
    bool grounded;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //float xmovedist = movex * speed * Time.deltaTime;
        //float ymovedist = movey * speed * Time.deltaTime;
        //transform.position = new Vector2(transform.position.x + xmovedist, transform.position.y + ymovedist);
        //for moving without rigid body
        rb.linearVelocity = new Vector2(movex * speed, rb.linearVelocity.y);
        if (movey > 0 && grounded)
        {
            rb.AddForce(new Vector2(0, jumpheight),ForceMode2D.Impulse);
        }
    }
    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        movex = v.x;
        movey = v.y;
        Debug.Log("X, " + movex);
        Debug.Log("Y, " + movey);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            grounded = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("collectible"))
        {
            score++;
            other.gameObject.SetActive(false);
            Debug.Log("score " + score);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            grounded = false;
        }
    }
}
