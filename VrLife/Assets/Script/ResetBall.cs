using UnityEngine;

public class ResetBall : MonoBehaviour
{
    public Transform pointSpawn;
    public GameObject ball;
    
    
    public void ResetBallToSpawn()
    {
        ball.transform.position = pointSpawn.position;
    }
}
