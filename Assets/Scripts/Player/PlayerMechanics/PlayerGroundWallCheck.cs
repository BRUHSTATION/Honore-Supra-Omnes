using UnityEngine;

public class PlayerGroundWallCheck : MonoBehaviour
{
    [SerializeField] private LayerMask _ground;
    [SerializeField] private LayerMask _wall;
    [SerializeField] private Transform _groundCheckStartPosition;
    [SerializeField] private Transform _wallCheckStartPosition;
    [SerializeField] private float _jumpSizeCheck;
    [SerializeField] private float _wallSizeCheck;

    private Vector2 _groundCheckPosition;
    private Vector2 _wallCheckPosition;

    // TEMP VARS
    [SerializeField] private bool _isGrounded;
    [SerializeField] private bool _isWalled;

    public bool isGrounded { get; private set; }

    private void Start()
    {
        _groundCheckPosition = _groundCheckStartPosition.position;
        _wallCheckPosition = _wallCheckStartPosition.position;
    }

    private void Update()
    {
        CheckingGround();
        CheckingWalls();
    }

    private void CheckingGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(_groundCheckPosition, -Vector2.up, _jumpSizeCheck, _ground);

        _isGrounded = hit;

        if (hit)
        {
            Debug.DrawRay(_groundCheckPosition, -Vector2.up * _jumpSizeCheck, Color.green);
        }
        else
        {
            Debug.DrawRay(_groundCheckPosition, -Vector2.up * _jumpSizeCheck, Color.red);
        }
    }

    private void CheckingWalls()
    {
        RaycastHit2D hit = Physics2D.Raycast(_wallCheckPosition, Vector2.right, _wallSizeCheck, _wall);

        _isWalled = hit;

        if (hit)
        {
            Debug.DrawRay(_wallCheckPosition, Vector2.right * _wallSizeCheck, Color.green);
        }
        else
        {
            Debug.DrawRay(_wallCheckPosition, Vector2.right * _wallSizeCheck, Color.red);
        }
    }
}