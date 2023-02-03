using System.Collections.Generic;
using UnityEngine;

public class PossibleRewards : MonoBehaviour
{
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

    public List<Reward> RewardsPool;

    private void Awake()
    {
        RewardsPool = new List<Reward>();
        GetPossibleRewards();
        GetRewardsPool();

        Debug.Log($"{RewardsPool.Count} rewards available.");
    }

    private void GetPossibleRewards()
    {
        var chestSpawner = GameObject.FindGameObjectWithTag("GameController").GetComponent<ChestSpawnerScript>();

        MaxHP = chestSpawner.MaxHP;
        CurrentHP = chestSpawner.CurrentHP;
        AttackPower = chestSpawner.AttackPower;
        AxeAttackPower = chestSpawner.AxeAttackPower;
        HammerAttackPower = chestSpawner.HammerAttackPower;
        Piercing = chestSpawner.Piercing;
        ShootingPower = chestSpawner.ShootingPower;
        MaxAmmo = chestSpawner.MaxAmmo;
        CritChancePercent = chestSpawner.CritChancePercent;
        Defense = chestSpawner.Defense;
        MovementSpeed = chestSpawner.MovementSpeed;
    }

    private void GetRewardsPool()
    {
        var fields = typeof(PossibleRewards).GetFields();
        foreach (var field in fields)
        {
            if (field.FieldType == typeof(int))
            {
                var fieldValue = int.Parse(field.GetValue(this).ToString());
                if (fieldValue > 0)
                {
                    RewardsPool.Add(
                    new Reward
                    {
                        StatToUpgrade = field.Name,
                        UpgradeValue = fieldValue
                    });
                }
            }
        }
    }
}
