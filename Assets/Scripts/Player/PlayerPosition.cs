using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    [SerializeField] private bool _isGrounded;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private CircleCollider2D _groundCheck;
    private Transform _groundCheckPosition;
    private float _groundCheckRadius;
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _groundCheckRadius = _groundCheck.radius;
        _groundCheckPosition = _groundCheck.gameObject.transform;
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        CheckingGround();

        if (_isGrounded)
        {
            _playerMovement.ResetJumpCount();
        }
    }

    private void CheckingGround()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheckPosition.position, _groundCheckRadius, _ground);
    }
}
