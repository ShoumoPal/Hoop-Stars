using UnityEngine;

public class RingController : MonoBehaviour
{

    protected void JumpLeft(Rigidbody rb, float _force)
    {
        SoundManager.Instance.PlaySFX(SoundType.Jump);

        rb.velocity = Vector3.zero;
        rb.AddForce(new Vector3(-1f, 2f, 0f) *  _force, ForceMode.Impulse);
    }

    protected void JumpRight(Rigidbody rb, float _force)
    {
        SoundManager.Instance.PlaySFX(SoundType.Jump);

        rb.velocity = Vector3.zero;
        rb.AddForce(new Vector3(1f, 2f, 0f) * _force, ForceMode.Impulse);
    }

    protected void FollowRingPosition(Transform objTransform, Vector3 offset)
    {
        objTransform.position = new Vector3(transform.position.x + offset.x,
                                            transform.position.y + offset.y,
                                            transform.position.z + offset.z);
    }
}
