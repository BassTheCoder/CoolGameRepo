using UnityEngine.SceneManagement;

public static class SceneSwapperScript
{
    public static void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public static void LoadKeybindsScene()
    {
        SceneManager.LoadScene("Keybinds");
    }

    public static void LoadLevelScene(int level)
    {
        SceneManager.LoadScene($"Level {level}");
    }
}
