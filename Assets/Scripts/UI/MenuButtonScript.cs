using UnityEngine;

public class MenuButtonScript : MonoBehaviour
{
    public void Intro()
    {
        SceneSwapperScript.LoadIntroScene();
    }
    
    public void NewGame()
    {
        SceneSwapperScript.LoadLevelScene(1);
    }

    public void GoToKeybinds()
    {
        SceneSwapperScript.LoadKeybindsScene();
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneSwapperScript.LoadMenuScene();
    }
}
