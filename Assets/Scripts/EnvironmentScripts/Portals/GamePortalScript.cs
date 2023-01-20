using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePortalScript : PortalScript
{
    private void Update()
    {
        if (IsCollidingWithPlayer && Input.GetKeyDown(Keybinds.Interact))
        {
            Debug.Log("Portal to game scene taken");
            SceneSwapperScript.LoadLevelScene(1);
        }
    }
}
