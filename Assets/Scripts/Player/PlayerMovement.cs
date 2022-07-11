using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _jumpForce = 5f; 
    private int _jumpCount;
    [SerializeField] private int _maxJumpCount;
    private float _movement;
    private bool _isFacingRight = true;
    private float _horizontal;
    private Rigidbody2D _rigidBody;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _jumpCount = _maxJumpCount;
    }

    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(_movement, 0, 0) * _speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && _jumpCount > 0)
        {
            _jumpCount--;
            _rigidBody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }

        Flip();
    }

    private void Flip()
    {
        if (_isFacingRight && _horizontal < 0f || !_isFacingRight && _horizontal > 0f)
        {
            _isFacingRight = !_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    public void ResetJumpCount()
    { 
        _jumpCount = _maxJumpCount; 
    }
}