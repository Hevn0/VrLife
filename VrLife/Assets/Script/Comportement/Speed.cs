using System;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public float speedMultiplier;
    
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.velocity *= speedMultiplier;
    }
}
