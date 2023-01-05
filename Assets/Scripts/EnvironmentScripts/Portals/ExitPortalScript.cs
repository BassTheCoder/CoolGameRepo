using UnityEngine;

public class ExitPortalScript : PortalScript
{
    private void Update()
    {
        if (IsCollidingWithPlayer && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("exit command invoked.");
            ExitProgramScript.ExitGame();
        }
    }
}
