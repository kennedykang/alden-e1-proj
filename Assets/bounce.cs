using UnityEngine;

public class bounce : MonoBehaviour
{
    Rigidbody2D b;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        b = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        b.AddForce(new Vector2(0, 500));
    }
}
