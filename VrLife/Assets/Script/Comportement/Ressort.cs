using UnityEngine;

public class Ressort : MonoBehaviour
{
    private static readonly int Boing = Animator.StringToHash("Boing");
    public float forceMultiplier;
    public Animator animator;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bille"))
        {
            animator.SetTrigger(Boing);
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.AddForce(transform.up * forceMultiplier, ForceMode.Impulse);
        }
    }
}
