using UnityEngine.SceneManagement;

public static class SceneSwapperScript
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
