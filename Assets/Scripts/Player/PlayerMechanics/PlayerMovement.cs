using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 1f;
    private Rigidbody2D _rigidBody;
    private float _movement;
    private bool _isFacingRight = true;
    
    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _movement = Input.GetAxis("Horizontal");

        Flip();
    }

    private void FixedUpdate()
    {
        if (_movement > 0.01f || _movement < -0.01f) 
            _rigidBody.MovePosition(_rigidBody.position + new Vector2(_movement, 0) * _movementSpeed * Time.fixedDeltaTime);
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
}