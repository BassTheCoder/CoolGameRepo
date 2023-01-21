using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemySpawner : MonoBehaviour
{
    public bool ShouldSpawn = true;
    public bool StopSpawningIfExitedArea = true;

    public Vector3[] PossibleSpawnPoints = null;
    public Vector3 BossSpawnPoint = default;

    public int AmountOfEnemiesToKill = 9;
    public int MaxEnemiesOnBoard = 3;

    public GameObject[] LevelEnemies = Array.Empty<GameObject>();
    public GameObject LevelBoss = null;

    private int _enemiesCount = default;
    private int _spawnCount = 0;

    private bool _allEnemiesKilled = false;
    private bool _bossSpawned = false;
    private bool _isPlayerInTriggerBox = false;

    public bool IsRoomFinished = false;

    private void Start()
    {
        if (LevelEnemies.Length == 0 || LevelBoss == null)
        {
            Debug.Log("Enemies or Boss missing for the level. (add in enemy spawner)");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isPlayerInTriggerBox = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (StopSpawningIfExitedArea && collision.CompareTag("Player"))
        {
            _isPlayerInTriggerBox = false;
        }
    }

    private void Update()
    {
        if (ShouldSpawn && !IsRoomFinished && _isPlayerInTriggerBox)
        {
            if (LevelEnemies.Length > 0)
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
                        if (LevelBoss != null)
                        {
                            SpawnBoss();
                        }
                    }
                }
                else
                {
                    Debug.Log("Congrats! You finished this room!");
                    IsRoomFinished = true;
                }
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

        var position = isBoss ? BossSpawnPoint : GetRandomSpawnPoint();

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
        var randomIndex = UnityEngine.Random.Range(0, PossibleSpawnPoints.Length);
        return PossibleSpawnPoints[randomIndex];
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
        if (LevelBoss != null)
        {
            return
            _enemiesCount == 0 &&
            _allEnemiesKilled &&
            _bossSpawned;
        }
        else
        {
            return
            _enemiesCount == 0 &&
            _allEnemiesKilled;
        }
    }
}
