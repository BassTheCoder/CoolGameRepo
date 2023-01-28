using UnityEngine.SceneManagement;

public static class SceneSwapperScript
{
    public static void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public static void LoadOptionsScene()
    {
        SceneManager.LoadScene("Options");
    }

    public static void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public static void LoadLevelScene(int level)
    {
        SceneManager.LoadScene($"Level {level}");
    }
}
