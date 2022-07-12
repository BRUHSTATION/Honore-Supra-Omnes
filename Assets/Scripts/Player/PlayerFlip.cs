using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    private bool _isFacingRight = true;
    private PlayerMovement _playerMovement;

    public bool isFacingRight => _isFacingRight;

    private void Start() => _playerMovement = GetComponent<PlayerMovement>();

    private void Update() => Flip();

    private void Flip()
    {
        if (_isFacingRight && _playerMovement.playerMovement < 0f || !_isFacingRight && _playerMovement.playerMovement > 0f)
        {
            _isFacingRight = !_isFacingRight;
            transform.rotation = Quaternion.Euler(0, !_isFacingRight ? 180f : 0, 0);
        }
    }
}
