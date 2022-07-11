using UnityEngine;

public class EnemyInteraction : MonoBehaviour
{
    [SerializeField] private int health = 1;
    [SerializeField] private int damage = 1;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerInteraction>(out PlayerInteraction player))
        {
           player.TakeDamage(damage);
        }
    }

    private void TakeDamage(int amount)
    {
        health -= amount;

        if(health <= 0f)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }
}