using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int AmountOfEnemiesToKill = 9;
    public int MaxEnemiesOnBoard = 3;

    public GameObject[] LevelEnemies = Array.Empty<GameObject>();

    private int _enemiesCount = default;
    private int _spawnCount = 0;

    private bool _allEnemiesKilled = false;

    private void Update()
    {
        if (LevelEnemies.Length > 0)
        {
            if (!_allEnemiesKilled)
            {
                UpdateEnemyCount();
                if (_enemiesCount == 0)
                {
                    for (int i = 1; i <= MaxEnemiesOnBoard; i++)
                    {
                        if (_spawnCount < AmountOfEnemiesToKill)
                        {
                            SpawnEnemy(GetRandomEnemyFromList());
                        }
                        else
                        {
                            _allEnemiesKilled = true;
                        }
                    }
                }
            }
            else
            {
                Debug.Log($"GZ! You've killed {AmountOfEnemiesToKill} enemies!");
            }
        }
        else
        {
            Debug.Log("Add enemies to enemiest list for the level.");
        }
    }

    private void UpdateEnemyCount()
    {
        _enemiesCount = GetActiveEnemies().Length;
    }

    private GameObject[] GetActiveEnemies()
    {
        return GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void SpawnEnemy(GameObject enemyGameObject, Stats stats = null)
    {
        if (enemyGameObject.TryGetComponent(typeof(Stats), out var objectStats))
        {
            objectStats = stats ?? objectStats;
        }
        var position = GetRandomSpawnPoint();

        Instantiate(enemyGameObject, position, Quaternion.identity, GameObject.Find("Enemies").transform);

        _spawnCount++;
    }

    private Vector3 GetRandomSpawnPoint()
    {
        Vector3[] possibleSpawnPoints = new Vector3[]
        {
            new Vector3(-1.2f, -0.8f),
            new Vector3(-1.2f, 0.5f),
            new Vector3(1f, -0.8f),
            new Vector3(1f, 0.5f),
        };

        var randomIndex = UnityEngine.Random.Range(0, possibleSpawnPoints.Length);
        return possibleSpawnPoints[randomIndex];
    }

    private GameObject GetRandomEnemyFromList()
    {
        var randomIndex = UnityEngine.Random.Range(0,LevelEnemies.Length);
        return LevelEnemies[randomIndex];
    }
}
