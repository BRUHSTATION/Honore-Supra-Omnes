using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementAcceleration;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _groundLinearDrag;

    private PlayerJump _playerJump;
    private Rigidbody2D _rigidBody;
    private float _movement;

    private bool _changingDirection => (_rigidBody.velocity.x > 0 && _movement < 0f) || (_rigidBody.velocity.y < 0f && _movement > 0f);

    public float playerMovement => _movement;

    private void Start()
    {
        _playerJump = GetComponent<PlayerJump>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update() => _movement = Input.GetAxis("Horizontal");

    private void FixedUpdate()
    {
        if (!_playerJump.isJumped)
        {
            Move();
            ApplyGroundLinearDrag();
        }
    }

    private void Move()
    {
        if (!_playerJump.isJumped)
        {
            _rigidBody.AddForce(new Vector2(_movement, 0) * _movementAcceleration * Time.deltaTime);
        }

        if (Mathf.Abs(_rigidBody.velocity.x) > _maxSpeed)
        {
            _rigidBody.velocity = new Vector2(Mathf.Sign(_rigidBody.velocity.x) * _maxSpeed, _rigidBody.velocity.y);
        }
    }

    public void ApplyGroundLinearDrag()
    {
        if (Mathf.Abs(_movement) < 0.4f || _changingDirection)
        {
            _rigidBody.drag = _groundLinearDrag;
        }
        else
        {
            _rigidBody.drag = 0;
        }
    }
}