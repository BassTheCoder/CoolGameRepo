using System.Linq;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public bool IsLevelFinished = false;

    private EnemySpawner[] ChildrenSpawners = null;

    private void Start()
    {
        ChildrenSpawners = transform.GetComponentsInChildren<EnemySpawner>();
    }

    private void Update()
    {
        CheckLevelFinish();
    }

    private void CheckLevelFinish()
    {
        if (ChildrenSpawners.Length > 0)
        {
            IsLevelFinished = ChildrenSpawners.All(childrenSpawner => childrenSpawner.IsRoomFinished == true);
        }
    }
}
