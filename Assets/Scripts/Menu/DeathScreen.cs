using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public void AwakeButton()
    {
        SceneManager.LoadScene(0);
    }

    public void ForgetButton()
    {
        SceneManager.LoadScene(2);
    }
}
