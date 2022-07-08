using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    public void TakeDamage(int damage)
    {
        gameObject.GetComponent<Health>().health -= damage;
        if (gameObject.GetComponent<Health>().health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        SceneManager.LoadScene(1);
    }
}
