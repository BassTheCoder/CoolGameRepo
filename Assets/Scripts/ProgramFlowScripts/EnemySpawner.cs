using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(WinCondition))]
public class EnemySpawner : MonoBehaviour
{
    public int AmountOfEnemiesToKill = 9;
    public int MaxEnemiesOnBoard = 3;

    public GameObject[] LevelEnemies = Array.Empty<GameObject>();
    public GameObject LevelBoss = null;

    private int _enemiesCount = default;
    private int _spawnCount = 0;

    private bool _allEnemiesKilled = false;
    private bool _bossSpawned = false;

    private void Start()
    {
        if (LevelEnemies.Length == 0 || LevelBoss == null)
        {
            Debug.Log("Enemies or Boss missing for the level. (add in enemy spawner)");
        }
    }

    private void Update()
    {
        if (LevelEnemies.Length > 0 && LevelBoss != null)
        {
            UpdateEnemyCount();
            CheckIfAllEnemiesAreKilled();

            if (!IsEverythingKilled())
            {
                if (!IsEverythingKilledExceptBoss())
                {
                    if (IsWaveKilled() && ShouldSpawnNextWave())
                    {
                        SpawnWave();
                    }
                }
                else
                {
                    SpawnBoss();
                }
            }
            else
            {
                Debug.Log("Congrats! You finished the level!");
                gameObject.GetComponent<WinCondition>().IsLevelFinished = true;
            }
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

    private void SpawnWave()
    {
        for (int i = 1; i <= MaxEnemiesOnBoard; i++)
        {
            if (_spawnCount < AmountOfEnemiesToKill)
            {
                SpawnEnemy(GetRandomEnemyFromList());
            }
            else
            {
                return;
            }
        }
    }

    private void SpawnEnemy(GameObject enemyGameObject, Stats stats = null, bool isBoss = false)
    {
        if (stats != null)
        {
            enemyGameObject.SetStats(stats);
        }

        var position = GetRandomSpawnPoint();

        Instantiate(enemyGameObject, position, Quaternion.identity, GameObject.Find("Enemies").transform);

        if (!isBoss)
        {
            _spawnCount++;
        }
        else
        {
            _bossSpawned = true;
        }
    }

    private void SpawnBoss()
    {
        SpawnEnemy(LevelBoss, isBoss: true);
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
        var randomIndex = UnityEngine.Random.Range(0, LevelEnemies.Length);
        return LevelEnemies[randomIndex];
    }

    private void CheckIfAllEnemiesAreKilled()
    {
        if (_spawnCount >= AmountOfEnemiesToKill)
        {
            _allEnemiesKilled = true;
        }
    }

    private bool IsWaveKilled()
    {
        return _enemiesCount == 0;
    }

    private bool ShouldSpawnNextWave()
    {
        return 
            _enemiesCount == 0 && 
            !_allEnemiesKilled;
    }

    private bool IsEverythingKilledExceptBoss()
    {
        return
            _enemiesCount == 0 &&
            _allEnemiesKilled &&
            !_bossSpawned;
    }

    private bool IsEverythingKilled()
    {
        return
            _enemiesCount == 0 &&
            _allEnemiesKilled &&
            _bossSpawned;
    }
}
