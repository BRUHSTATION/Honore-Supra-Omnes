using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private bool _isGrounded;
    public LayerMask Ground;
    public Transform GroundCheck;
    private float _groundCheckRadius;
    private PlayerMovement _movement;

    private void Start()
    {
        _groundCheckRadius = GroundCheck.GetComponent<CircleCollider2D>().radius;
        _movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        CheckingGround();
        if (_isGrounded)
        {
            _movement.ResetJumpCount();
        }
    }

    void CheckingGround()
    {
        _isGrounded = Physics2D.OverlapCircle(GroundCheck.position, _groundCheckRadius, Ground);
    }
}
