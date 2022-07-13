using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private int _extraJumps;

    [Header("Phisics variables")]
    [SerializeField] private float _jumpForce;
    [Tooltip("Сила, которая действует во время набора высоты")]
    [SerializeField] private float _airLinearDrag;
    [Tooltip("Скорость падения")]
    [SerializeField] private float _fallMultiplier;
    [Tooltip("Скорость падения при нажатом Space")]
    [SerializeField] private float _lowJumpFallMultiplier;

    private int _extraJumpsValue;
    private PlayerGroundCheck _playerGroundCheck;
    private PlayerMovement _playerMovement;
    private Rigidbody2D _rigidBody;

    private bool _onGround => _playerGroundCheck.isGrounded;
    private bool _canJump => Input.GetKeyDown(KeyCode.Space) && (_onGround || _extraJumpsValue > 0);

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _playerGroundCheck = GetComponent<PlayerGroundCheck>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (_canJump) Jump();

        if (_onGround)
        {
            _extraJumpsValue = _extraJumps;
            _playerMovement.ApplyGroundLinearDrag();
        }
        else
        {
            ApplyLinearAirDrag();
            FallMultiplier();
        }
    }

    private void Jump()
    {
        if (!_onGround) _extraJumpsValue--;

        _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, 0);
        _rigidBody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void ApplyLinearAirDrag() => _rigidBody.drag = _airLinearDrag;

    private void FallMultiplier()
    {
        if (_rigidBody.velocity.y < 0)
        {
            _rigidBody.gravityScale = _fallMultiplier;
        }
        else if (_rigidBody.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            _rigidBody.gravityScale = _lowJumpFallMultiplier;
        }
        else
        {
            _rigidBody.gravityScale = 1f;
        }
    }
}