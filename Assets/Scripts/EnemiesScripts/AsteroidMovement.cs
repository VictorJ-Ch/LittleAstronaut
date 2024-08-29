using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public float asteroidSpeed = 5.0f;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearDamping = 0.0f;
        rb.angularDamping = 0.0f;
        rb.linearVelocity = new Vector3(Random.Range(-1.0f,1.0f), Random.Range(-1.0f, 1.0f), 0.0f).normalized * asteroidSpeed;
        rb.angularVelocity = Random.Range(-50.0f, 50.0f);
    }

    void Update()
    {
    }
}
