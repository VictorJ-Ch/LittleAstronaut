using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 touchPosition, direction;
    Rigidbody2D rb;
    public float moveSpeed = 10.0f;
    Touch playerTouch;
    public Camera playerCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovementTouch();
        //MovementMouse();
    }

    void MovementTouch()
    {
        print("Input" + Input.touchCount);
        if (Input.touchCount > 0)
        {
            // Touch detection
            playerTouch = Input.GetTouch(0);
            touchPosition = playerCamera.ScreenToWorldPoint(playerTouch.position);
            // Touch movement
            touchPosition.z = 0.0f;
            direction = (touchPosition - transform.position).normalized; // Normalizamos la dirección
            rb.linearVelocity = new Vector2(direction.x, direction.y) * moveSpeed; // Aplicar velocidad sin Time.deltaTime
            print("Se esta moviendo");

            // Validator What if is not touching
            if (playerTouch.phase == TouchPhase.Ended || playerTouch.phase == TouchPhase.Canceled)
            {
                rb.linearVelocity = Vector2.zero; // Detener el movimiento
            }
        }
    }

    void MovementMouse()
    {
        if (Input.GetMouseButton(0)) // Left
        {
            Vector3 mousePosition = playerCamera.ScreenToWorldPoint(Input.mousePosition);
            // Mouse Movement
            mousePosition.z = 0.0f;
            direction = (mousePosition - transform.position).normalized; // Normalizamos la dirección
            rb.linearVelocity = new Vector2(direction.x, direction.y) * moveSpeed; // Aplicar velocidad sin Time.deltaTime
            print("Se está moviendo con el mouse");
        }
        // Not touching
        if (Input.GetMouseButtonUp(0))
        {
            rb.linearVelocity = Vector2.zero; // Detener el movimiento
        }
    }
}
