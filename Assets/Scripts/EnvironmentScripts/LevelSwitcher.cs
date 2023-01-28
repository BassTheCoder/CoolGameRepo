using UnityEngine;

public class LevelSwitcher : MonoBehaviour
{
    void Update()
    {
        var playerObject = GameObject.FindGameObjectWithTag("Player");
        if (Input.GetKeyDown(KeyCode.Escape) || playerObject == null)
        {
            SceneSwapperScript.LoadMenuScene();
        }
    }
}
