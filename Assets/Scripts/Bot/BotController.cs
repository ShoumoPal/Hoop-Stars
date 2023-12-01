using UnityEngine;

// Script used for the Bot AI in the game

public class BotController : RingController
{
    [SerializeField] private Transform _goal;
    [SerializeField] private float _jumpDelay;
    [SerializeField] private float _force;
    [SerializeField] private TextMesh _botTag;
    [SerializeField] private Vector3 _tagOffset;

    private Rigidbody _botRb;

    private void Start()
    {
        _botRb = GetComponent<Rigidbody>();
        InvokeRepeating(nameof(BotDelayJump), 2f, _jumpDelay);
    }

    private void Update()
    {
        // Inherited function

        FollowRingPosition(_botTag.transform, _tagOffset);
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
