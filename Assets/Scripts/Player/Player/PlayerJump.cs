using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 5;
    [SerializeField] private float _jumpTime;
    [SerializeField] private bool _isJumping;

    private float _jumpTimeCounter;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (gameObject.GetComponent<GroundWallCheck>()._isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            _isJumping = true;
            _jumpTimeCounter = _jumpTime;
            rb.velocity = Vector2.up * _jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && _isJumping == true)
        {
            if (_jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * _jumpForce;
                _jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                _isJumping = false;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                _isJumping = false;
            }
        }
    }
}
