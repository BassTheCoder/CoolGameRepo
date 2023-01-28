using TMPro;
using UnityEngine;

public class UI_EnemyCounterScript : MonoBehaviour
{
    private EnemySpawner[] EnemySpawners = null;

    private int TotalEnemies = 0;

    private void Start()
    {
        var gameManager = GameObject.FindGameObjectWithTag("GameController");
        EnemySpawners = gameManager.transform.GetComponentsInChildren<EnemySpawner>();
        UpdateEnemyCount();
        UpdateUICounter();
    }

    private void UpdateEnemyCount()
    {
        foreach (var spawner in EnemySpawners)
        {
            TotalEnemies += spawner.AmountOfEnemiesToKill;
            if (spawner.LevelBoss != null)
            {
                TotalEnemies += 1;
            }
        }
    }

    private void UpdateUICounter()
    {
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = TotalEnemies.ToString();
    }
}
