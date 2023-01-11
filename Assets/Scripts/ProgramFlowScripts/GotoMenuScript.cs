using UnityEngine;

public class GotoMenuScript : MonoBehaviour
{
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
            SceneSwapperScript.LoadMenuScene();
        }
    }
}
