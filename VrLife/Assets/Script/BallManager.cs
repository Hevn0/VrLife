using System;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [Header("Balls")]
    public GameObject ball1;
    public GameObject ball2;
    
    [Header("SpawnPoint")]
    public Transform pointSpawn1;
    public Transform pointSpawn2;
    
    private Rigidbody rb1;
    private Rigidbody rb2;

    private void Start()
    {
        rb1 = ball1.GetComponent<Rigidbody>();
        rb2 = ball2.GetComponent<Rigidbody>();
    }

    public void ResetBallToSpawn()
    {
        rb1.linearVelocity = Vector3.zero;
        rb2.linearVelocity = Vector3.zero;
        
        rb1.isKinematic = true;
        rb2.isKinematic = true;
        
        ball1.transform.position = pointSpawn1.position;
        ball2.transform.position = pointSpawn2.position;
    }

    public void LaunchBall()
    {
        rb1.isKinematic = false;
        rb2.isKinematic = false;
    }
}
