using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy1 = null;
    public GameObject Enemy2 = null;
    public GameObject Enemy3 = null;

    private List<GameObject> _levelEnemies = default;
    private int _enemiesCount = default;

    private void Start()
    {
        _levelEnemies = new List<GameObject>();
        GetLevelEnemiesList();
    }

    private void Update()
    {
        UpdateEnemyCount();
        if (_enemiesCount == 0 && _levelEnemies.Count > 0)
        {
            SpawnEnemy(GetRandomEnemyFromList());
            SpawnEnemy(GetRandomEnemyFromList());
            SpawnEnemy(GetRandomEnemyFromList());
        }
    }

    private void GetLevelEnemiesList()
    {
        if (Enemy1 != null)
            _levelEnemies.Add(Enemy1);
        if (Enemy2 != null)
            _levelEnemies.Add(Enemy2); 
        if (Enemy3 != null)
            _levelEnemies.Add(Enemy3);
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

        return possibleSpawnPoints[UnityEngine.Random.Range(0, possibleSpawnPoints.Length)];
    }

    private GameObject GetRandomEnemyFromList()
    {
        var randomIndex = UnityEngine.Random.Range(0,_levelEnemies.Count);
        return _levelEnemies[randomIndex];
    }
}
