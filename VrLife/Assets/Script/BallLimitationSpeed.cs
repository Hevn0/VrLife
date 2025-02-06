using UnityEngine;

public class BallLimitationSpeed : MonoBehaviour
{
    private Rigidbody rb;
    public float maxSpeed = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxSpeed);
        }
    }
}
