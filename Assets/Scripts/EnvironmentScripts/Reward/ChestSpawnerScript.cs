using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawnerScript : MonoBehaviour
{
    public GameObject ChestObject = null;
    public Vector3 ChestSpawnPoint = Vector3.zero;

    private bool _chestSpawned = false;
    private bool _shouldSpawnRewardChest = false;

    void Start()
    {
        if (ChestObject == null)
        {
            Debug.Log("There's no reward chest for the level.");
        }
    }

    void Update()
    {
        CheckIfShouldSpawnChest();

        if (_shouldSpawnRewardChest)
        {
            SpawnRewardChest();
        }
    }

    private void SpawnRewardChest()
    {
        Instantiate(ChestObject, ChestSpawnPoint, Quaternion.identity);
        _chestSpawned = true;
    }

    private void CheckIfShouldSpawnChest()
    {
        _shouldSpawnRewardChest =
            GetComponent<WinCondition>().IsLevelFinished &&
            !_chestSpawned;
    }
}
