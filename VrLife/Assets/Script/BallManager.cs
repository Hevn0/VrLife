using System;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public Transform pointSpawn;
    public GameObject ball;
    
    private Rigidbody rb;

    private void Start()
    {
        rb = ball.GetComponent<Rigidbody>();
    }

    public void ResetBallToSpawn()
    {
        rb.linearVelocity = Vector3.zero;
        rb.isKinematic = true;
        ball.transform.position = pointSpawn.position;
    }

    public void LaunchBall()
    {
        rb.isKinematic = false;
    }
}
