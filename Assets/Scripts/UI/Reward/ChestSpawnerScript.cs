using UnityEngine;

public class ChestSpawnerScript : MonoBehaviour
{
    public GameObject ChestObject = null;
    public Vector3 ChestSpawnPoint = Vector3.zero;

    public int MaxHP = 0;
    public int CurrentHP = 0;
    public int AttackPower = 0;
    public int AxeAttackPower = 0;
    public int HammerAttackPower = 0;
    public int Piercing = 0;
    public int ShootingPower = 0;
    public int MaxAmmo = 0;
    public int CritChancePercent = 0;
    public int Defense = 0;
    public int MovementSpeed = 0;

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
        if (GameObject.FindGameObjectWithTag("RewardChest") != null)
        {
            _chestSpawned = true;
        }
    }

    private void CheckIfShouldSpawnChest()
    {
        _shouldSpawnRewardChest =
            GetComponent<WinCondition>().IsLevelFinished &&
            !GetComponent<WinCondition>().LastLevel &&
            !_chestSpawned;
    }
}
