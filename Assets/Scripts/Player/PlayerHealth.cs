using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    [SerializeField] private int numOfHearts;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    void Update()
    {
        if (health > numOfHearts) 
        { 
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++) 
        {
            if (i < health) 
            {
                hearts[i].sprite = fullHeart;
            } 
            else 
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts) 
            {
                hearts[i].enabled = true;
            } 
            else 
            {
                hearts[i].enabled = false;
            }
        }
    }
}