using UnityEngine;

public class PlayerWallCheck : MonoBehaviour
{
    [SerializeField] private bool _showGizmos;
    [SerializeField] private LayerMask _wall;
    [SerializeField] private Transform _wallCheckStartPosition;
    [SerializeField] private float _wallSizeCheck;

    private bool _isWalled;

    public bool isWalled => _isWalled;

    private void Update()
    {
        CheckingWalls();
    }

    private void CheckingWalls()
    {
        _isWalled = Physics2D.Raycast(_wallCheckStartPosition.position, Vector2.right, _wallSizeCheck, _wall);
    }

    private void OnDrawGizmos()
    {
        if (_showGizmos)
        {
            Gizmos.color = _isWalled ? Color.green : Color.red;

            Gizmos.DrawLine(_wallCheckStartPosition.position,
                new Vector2(_wallCheckStartPosition.position.x, _wallCheckStartPosition.position.y) + Vector2.right* _wallSizeCheck);
        }
    }
}
