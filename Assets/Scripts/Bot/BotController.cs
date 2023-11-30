using UnityEngine;

public class BotController : RingController
{
    [SerializeField] private Transform _goal;
    [SerializeField] private float _jumpDelay;
    [SerializeField] private float _force;

    private Rigidbody _botRb;

    private void Start()
    {
        _botRb = GetComponent<Rigidbody>();
        InvokeRepeating(nameof(BotDelayJump), 2f, _jumpDelay);
    }

    private void BotDelayJump()
    {
        if(transform.position.y < _goal.position.y)
        {
            if (transform.position.x > _goal.position.x)
            {
                JumpLeft(_botRb, _force);
            }
            else
            {
                JumpRight(_botRb, _force);
            }
        }
    }
}
