using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float movex;
    float movey;
    [SerializeField] float speed = 5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xmovedist = movex * speed * Time.deltaTime;
        float ymovedist = movey * speed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + xmovedist, transform.position.y + ymovedist);
    }
    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        movex = v.x;
        movey = v.y;
        Debug.Log("X, " + movex);
        Debug.Log("Y, " + movey);
    }
}
