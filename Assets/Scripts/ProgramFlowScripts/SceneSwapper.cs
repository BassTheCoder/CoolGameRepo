using UnityEngine.SceneManagement;

public static class SceneSwapper
{
    public static void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public static void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
