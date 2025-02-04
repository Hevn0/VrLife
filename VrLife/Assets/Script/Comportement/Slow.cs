using System;
using UnityEngine;

public class Slow : MonoBehaviour
{
    [Range(0,1)] public float slowMultiplier;
    
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.velocity *= slowMultiplier;
    }
}
