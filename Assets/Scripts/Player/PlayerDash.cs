using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] private float _dashingPower = 24f;
    [SerializeField] private float _dashingTime = 0.2f;
    [SerializeField] private float _dashingCooldown = 1f;
    [SerializeField] private TrailRenderer _trailRenderer;
    private Rigidbody2D _rigidBody;
    private bool _canDash = true;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && _canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        _canDash = false;
        float originalGravity = _rigidBody.gravityScale;
        _rigidBody.gravityScale = 0f;
        _rigidBody.velocity = new Vector2(transform.localScale.x * _dashingPower, 0f);
        _trailRenderer.emitting = true;
        yield return new WaitForSeconds(_dashingTime);
        _trailRenderer.emitting = false;
        _rigidBody.gravityScale = originalGravity;
        yield return new WaitForSeconds(_dashingCooldown);
        _canDash = true;
    }
}