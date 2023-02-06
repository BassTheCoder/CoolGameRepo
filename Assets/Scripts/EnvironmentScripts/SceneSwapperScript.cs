using UnityEngine.SceneManagement;

public static class SceneSwapperScript
{
    public static void LoadIntroScene()
    {
        SceneManager.LoadScene("Intro");
    }
    
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

    public static void LoatWinScene()
    {
        SceneManager.LoadScene("GameFinished");
    }

    public static void LoadFailScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}
