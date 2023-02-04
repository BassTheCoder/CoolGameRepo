using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("GameController").GetComponent<WinCondition>().IsLevelFinished)
        {
            Destroy(gameObject);
        }
    }
}
