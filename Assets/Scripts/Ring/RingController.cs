using UnityEngine;

public class RingController : MonoBehaviour
{

    protected void JumpLeft(Rigidbody rb, float _force)
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(new Vector3(-1f, 2f, 0f) *  _force, ForceMode.Impulse);
    }

    protected void JumpRight(Rigidbody rb, float _force)
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(new Vector3(1f, 2f, 0f) * _force, ForceMode.Impulse);
    }
}
