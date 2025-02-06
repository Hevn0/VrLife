using UnityEngine;

public class Ressort : MonoBehaviour
{
    public float forceMultiplier;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bille"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.AddForce(transform.up * forceMultiplier, ForceMode.Impulse);
        }
    }
}
