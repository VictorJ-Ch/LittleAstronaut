using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 touchPosition, direction;
    Rigidbody2D rb;
    public float moveSpeed = 10.0f;
    Touch playerTouch;
    public Camera camera;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        print("Input" + Input.touchCount);
        if(Input.touchCount > 0)
        {
            //Touch detection
            playerTouch = Input.GetTouch(0);
            touchPosition = camera.ScreenToWorldPoint(playerTouch.position);
            //Touch movement
            touchPosition.z = 0.0f;
            direction = touchPosition - transform.position;
            rb.linearVelocity = new Vector2(direction.x, direction.y) * moveSpeed * Time.deltaTime;
            print("Se esta moviendo");
            //Validator What if is not touching
            if (playerTouch.phase == TouchPhase.Ended)
            {
                rb.linearVelocity = Vector2.zero;
            }
        }
    }
}
