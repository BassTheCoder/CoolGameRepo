using UnityEngine;

public class GotoMenuScript : MonoBehaviour
{
    void Update()
    {
        var playerObject = GameObject.FindGameObjectWithTag("Player");
        if (Input.GetKeyDown(KeyCode.Escape) || playerObject == null)
        {
            SceneSwapper.LoadMenuScene();
        }
    }
}
