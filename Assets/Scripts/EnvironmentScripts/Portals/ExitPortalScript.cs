using UnityEngine;

public class ExitPortalScript : PortalScript
{
    private void Update()
    {
        if (IsCollidingWithPlayer && Input.GetKeyDown(Keybinds.Interact))
        {
            Debug.Log("exit command invoked.");
            ExitProgramScript.ExitGame();
        }
    }
}
