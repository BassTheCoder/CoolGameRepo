using System.Collections.Generic;
using UnityEngine;

public class PossibleRewards : MonoBehaviour
{
    public int MaxHpUpgrade = 0;
    public int Heal = 0;
    public int AttackPowerUpgrade = 0;
    public int ShootingPowerUpgrade = 0;
    public int MaxAmmoUpgrade = 0;
    public int CritChancePercentUpgrade = 0;
    public int DefenseUpgrade = 0;

    public List<Reward> RewardsPool;

    private void Awake()
    {
        RewardsPool = new List<Reward>();
        GetRewardsPool();

        Debug.Log($"{RewardsPool.Count} rewards available.");
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
