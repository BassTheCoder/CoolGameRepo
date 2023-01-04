using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapper : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
