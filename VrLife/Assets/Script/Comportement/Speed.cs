using System;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public float speedMultiplier;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bille"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            Vector3 forceDirection = rb.linearVelocity;
            rb.AddForce(forceDirection * speedMultiplier, ForceMode.Impulse);
        }
    }
}
