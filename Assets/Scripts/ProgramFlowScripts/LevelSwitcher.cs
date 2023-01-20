using UnityEngine;

public class LevelSwitcher : MonoBehaviour
{
    public int NextLevel = 0;
    void Update()
    {
        var playerObject = GameObject.FindGameObjectWithTag("Player");
        if (Input.GetKeyDown(KeyCode.Escape) || playerObject == null)
        {
            SceneSwapperScript.LoadMenuScene();
        }

        var winCondition = gameObject.GetComponent<WinCondition>()?.IsLevelFinished;
        if (winCondition != null && winCondition == true) 
        {
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        if (NextLevel == 0)
        {
            SceneSwapperScript.LoadMenuScene();
        }
        else
        {
            SceneSwapperScript.LoadLevelScene(NextLevel);
        }
    }
}
