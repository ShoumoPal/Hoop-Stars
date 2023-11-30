using UnityEngine;

public class PlayerController : RingController
{
    [SerializeField] private static PlayerController instance;
    public static PlayerController Instance { get { return instance; } }

    [SerializeField] private float _force;
    [SerializeField] private float _boundY;

    private bool _inYBound;
    private Rigidbody playerRb;

    private void Awake()
    {
        _inYBound = true;
        instance = this;
    }

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CheckBound();
    }
    
    private void CheckBound()
    {
        if (transform.position.y > _boundY)
        {
            _inYBound = false;
        }
        else
        {
            _inYBound = true;
        }
    }
    public void OnJumpLeft()
    {
        if (_inYBound)
        {
            JumpLeft(playerRb, _force);
        }
    }

    public void OnJumpRight() 
    { 
        if (_inYBound)
        {
            JumpRight(playerRb, _force);
        }
    }
}

