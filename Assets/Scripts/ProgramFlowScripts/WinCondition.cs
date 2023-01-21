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
        if (IsLevelFinished)
        {
            GameObject.FindGameObjectWithTag("Portal").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.FindGameObjectWithTag("Portal").GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void CheckLevelFinish()
    {
        if (ChildrenSpawners.Length > 0)
        {
            IsLevelFinished = ChildrenSpawners.All(childrenSpawner => childrenSpawner.IsRoomFinished == true);
        }
    }
}
