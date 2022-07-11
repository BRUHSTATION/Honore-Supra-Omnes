using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    private PlayerHealth _playerHealth;

    private void Start()
    {
        _playerHealth = GetComponent<PlayerHealth>();
    }
    public void TakeDamage(int damage)
    {
        _playerHealth.health -= damage;
        if (_playerHealth.health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        SceneManager.LoadScene(1);
    }
}
