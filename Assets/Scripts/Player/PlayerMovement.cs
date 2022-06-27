using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _runSpeed = 300f;
    [SerializeField] private float _jumpForce = 10.0f;
    [SerializeField] private Collider2D _collider;


    private Rigidbody2D _rigidbody;
    private PlayerActionsMap _playerActionsMap;
    private float _moveInput;

    private void OnEnable()
    {
        _playerActionsMap.Enable();
        _playerActionsMap.Player.Jump.started += context => Jump();
    }

    private void OnDisable()
    {
        _playerActionsMap.Disable();
        _playerActionsMap.Player.Jump.started -= context => Jump();
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _playerActionsMap = new PlayerActionsMap();
    }

    private void FixedUpdate()
    {
        _moveInput = _playerActionsMap.Player.Move.ReadValue<float>();
        _rigidbody.velocity = new Vector2(_moveInput * _runSpeed, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        // if (OnJumpablePlace())
        // {
            _rigidbody.AddForce(new Vector2(0f, _jumpForce));
            Debug.Log("Jump");
        // }
    }

    // collider.gameObject.GetComponent<Ground>().IsJumpable; 
    private bool OnJumpablePlace()
    {
      
        RaycastHit2D hitObject = Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size,
            0f, Vector2.down, _collider.bounds.size.x);
        
        Debug.Log("1");
        if (hitObject)
        {
            bool boolic = hitObject.transform.GetComponent<Ground>().debug;
            return boolic;
        }
        return false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        // if (OnJumpablePlace())
        // {
        //     Gizmos.color = Color.green;
        // }
        // else
        // {
        //     Gizmos.color = Color.red;
        // }_collider.bounds.center, Vector2.right,1f
        Gizmos.DrawWireCube(_collider.bounds.center + new Vector3(0, -_collider.bounds.size.x, 0 ), _collider.bounds.size);
    }

}

