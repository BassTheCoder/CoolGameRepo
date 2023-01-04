using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePortalScript : PortalScript
{
    private void Update()
    {
        if (IsCollidingWithPlayer && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Portal to game scene taken");
            SceneSwapper.LoadGameScene();
        }
    }
}
