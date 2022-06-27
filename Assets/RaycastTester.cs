using System;
using UnityEngine;

public class RaycastTester : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    
    private void Start()
    {
        
    }

    void Update()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        RaycastHit2D hit = Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size,
        0f, Vector2.down, 1f);
        if(hit && GetComponent<SpriteRenderer>().color == Color.red)
        GetComponent<SpriteRenderer>().color = hit.transform.GetComponent<SpriteRenderer>().color;
        
    }
}
