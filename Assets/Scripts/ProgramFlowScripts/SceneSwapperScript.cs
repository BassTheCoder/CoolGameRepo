using UnityEngine.SceneManagement;

public static class SceneSwapperScript
{
    public static void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public static void LoadLevel1Scene()
    {
        SceneManager.LoadScene("Level 1");
    }

    public static void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
