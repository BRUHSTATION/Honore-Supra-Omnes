using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _jumpSizeCheck;
    [SerializeField] private float _jumpSizeCheckOffset;

    private bool _isGrounded;

    public bool isGrounded => _isGrounded;

    private void Update() => CheckingGround();

    private void CheckingGround() => _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, _jumpSizeCheck, _groundLayer);

    private void OnDrawGizmos()
    {
        Gizmos.color = _isGrounded ? Color.green : Color.red;

        Vector2 _offsetPosition = new Vector2(transform.position.x + _jumpSizeCheckOffset, transform.position.y);

        Gizmos.DrawLine(_offsetPosition, _offsetPosition + Vector2.down * _jumpSizeCheck);
    }
}