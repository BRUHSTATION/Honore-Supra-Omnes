using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _jumpForce = 5f; 
    [SerializeField] private int _maxJumpCount;
    private Rigidbody2D _rigidBody;
    private float _movement;
    private int _jumpCount;
    private bool _isFacingRight = true;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _jumpCount = _maxJumpCount;
    }

    private void Update()
    {
        _movement = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && _jumpCount > 0) Jump();

        Flip();
    }

    private void FixedUpdate()
    {
        if (_movement > 0.01f || _movement < -0.01f) 
            _rigidBody.MovePosition(_rigidBody.position + new Vector2(_movement, 0) * _speed * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        _jumpCount--;
        _rigidBody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
    }

    private void Flip()
    {
        if (_isFacingRight && _movement < 0f || !_isFacingRight && _movement > 0f)
        {
            _isFacingRight = !_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public void ResetJumpCount() => _jumpCount = _maxJumpCount;
}