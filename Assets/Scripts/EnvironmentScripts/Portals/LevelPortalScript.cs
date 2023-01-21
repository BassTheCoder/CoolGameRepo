using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPortalScript : PortalScript
{
    public int NextLevel = 0;

    private void Update()
    {
        if (IsCollidingWithPlayer && Input.GetKeyDown(Keybinds.Interact))
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
