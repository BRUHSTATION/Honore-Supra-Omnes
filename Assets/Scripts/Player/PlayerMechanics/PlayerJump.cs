using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private int _maxJumpCount;
    [SerializeField] private float _jumpCheckDelay;

    private PlayerGroundWallCheck _playerGroundCheck;
    private Rigidbody2D _rigidBody;
    private int _jumpCount;
    private bool _isJumped;

    private void Start()
    {
        _jumpCount = _maxJumpCount;
        _rigidBody = GetComponent<Rigidbody2D>();
        _playerGroundCheck = GetComponent<PlayerGroundWallCheck>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _jumpCount > 0) Jump();

        if (_playerGroundCheck.isGrounded && _isJumped) ResetJumpsHandler();
    }

    private void ResetJumpsHandler() => StartCoroutine(ResetJumpsWhileGrounded());

    private IEnumerator ResetJumpsWhileGrounded()
    {
        yield return new WaitForSeconds(_jumpCheckDelay);

        if (_playerGroundCheck.isGrounded)
        {
            ResetJumpCount();
            _isJumped = false;
        }
    }

    private void Jump()
    {
        _jumpCount--;
        _rigidBody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        _isJumped = true;
    }

    public void ResetJumpCount() => _jumpCount = _maxJumpCount;
}
