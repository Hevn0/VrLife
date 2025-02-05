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
            rb.AddForce(speedMultiplier * rb.transform.position, ForceMode.Impulse);
        }
    }
}
