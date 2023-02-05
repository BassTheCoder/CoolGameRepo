using System.Linq;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public EnemySpawner[] SpawnersClearedRequiredToOpen = new EnemySpawner[0];
    public bool IsLevelExit = false;

    private void Update()
    {
        if (CheckIfShouldOpen())
        {
            Destroy(gameObject);
        }
    }

    private bool CheckIfShouldOpen() =>
        (IsLevelExit && GameObject.FindGameObjectWithTag("GameController").GetComponent<WinCondition>().IsLevelFinished) ||
        (SpawnersClearedRequiredToOpen.Length > 0 && SpawnersClearedRequiredToOpen.All(spawner => spawner.IsRoomFinished));
}
