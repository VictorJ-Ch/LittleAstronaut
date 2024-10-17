using UnityEngine;
using UnityEngine.InputSystem;
using PlayerInputActions;

public class PlayerMovementNewInput : MonoBehaviour
{
    private PlayerInputMap playerInputActions;
    private Rigidbody2D rb;
    private Vector3 touchPosition, direction;
    public float moveSpeed = 10.0f;
    public Camera camera;

    private void Awake()
    {
        playerInputActions = new PlayerInputMap(); // Usamos el nuevo nombre de la clase
    }

    private void OnEnable()
    {
        playerInputActions.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Asegurarse de que la cámara esté asignada
        if (camera == null)
        {
            camera = Camera.main;
        }
    }

    void Update()
    {
        MovementTouch();
        MovementMouse();
    }

    void MovementTouch()
    {
        // Verificar si el toque está siendo detectado
        if (Touchscreen.current != null)
        {
            Debug.Log("Pantalla táctil detectada");
        }

        // Si el toque ha sido realizado
        if (playerInputActions.Player.TouchPress.phase == InputActionPhase.Performed)
        {
            Debug.Log("Toque detectado");

            // Obtener la posición del toque
            Vector2 screenPosition = playerInputActions.Player.TouchPosition.ReadValue<Vector2>();
            touchPosition = camera.ScreenToWorldPoint(screenPosition);
            touchPosition.z = 0.0f;

            Debug.Log("Posición del toque: " + touchPosition);

            // Movimiento en la dirección del toque
            direction = (touchPosition - transform.position).normalized; // Normalizamos la dirección
            rb.velocity = direction * moveSpeed; // Aplicar velocidad
            Debug.Log("Dirección: " + direction + ", Velocidad: " + rb.velocity);
        }

        // Cuando el toque se cancela o se detiene
        if (playerInputActions.Player.TouchPress.phase == InputActionPhase.Canceled)
        {
            rb.velocity = Vector2.zero; // Detener el movimiento
            Debug.Log("Movimiento detenido");
        }
    }
    void MovementMouse()
    {
        // Verifica si el botón izquierdo del mouse fue presionado este frame
        if (playerInputActions.Player.MouseClick.WasPerformedThisFrame())
        {
            // Lee la posición actual del mouse
            Vector2 screenPosition = playerInputActions.Player.MousePosition.ReadValue<Vector2>();
            Vector3 mousePosition = camera.ScreenToWorldPoint(screenPosition);

            // Ajustamos la posición z
            mousePosition.z = 0.0f;
            Vector3 direction = (mousePosition - transform.position).normalized;

            // Aplicamos el movimiento
            rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;
            print("Se mueve con mouse");
        }

        // Si el botón del mouse se soltó, detenemos el movimiento
        if (playerInputActions.Player.MouseClick.WasReleasedThisFrame())
        {
            rb.velocity = Vector2.zero; // Detener el movimiento
        }
    }
}
