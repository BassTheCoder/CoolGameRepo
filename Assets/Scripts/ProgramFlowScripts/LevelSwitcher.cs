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
            GameObject.FindGameObjectWithTag("Portal").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.FindGameObjectWithTag("Portal").GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
