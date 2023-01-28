using UnityEngine;

public class MenuButtonScript : MonoBehaviour
{
    public void NewGame()
    {
        SceneSwapperScript.LoadLevelScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
