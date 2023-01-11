using UnityEngine;

[RequireComponent(typeof(Stats))]
public class CombatBase : MonoBehaviour
{
    protected Stats Stats;

    private bool _isEntityAlive = true;

    protected bool RollForCrit()
    {
        var random = new System.Random();
        var roll = random.Next(0, 100);
        if (roll <= Stats.CritChancePercent)
        {
            return true;
        }
        return false;
    }

    protected void GetStats()
    {
        Stats = gameObject.GetComponentInParent<Stats>();
    }

    protected void HealFor(int amount)
    {
        Stats.CurrentHP += amount;
    }

    protected void GetHitFor(int damage)
    {
        var finalDamage = CalculateDamage(damage);
        Stats.CurrentHP -= finalDamage;
    }

    private int CalculateDamage(int damage)
    {
        var damageRegardingDefense = damage * GetDefenseAsDamageMultiplier();
        var finalDamage = Mathf.FloorToInt(damageRegardingDefense);
        if (finalDamage < 1)
        {
            finalDamage = 1;
        }
        return finalDamage;
    }

    protected void UpdateMaxHpFor(int amount)
    {
        Stats.MaxHP += amount;
    }

    protected void UpdateCritChanceFor(int amount)
    {
        Stats.CritChancePercent += amount;
    }

    protected void UpdateDefenseFor(int amount)
    {
        Stats.Defense += amount;
    }

    protected int GetCurrentHp()
    {
        return Stats.CurrentHP;
    }

    protected int GetCurrentHpPercent()
    {
        var maxHp = (float)Stats.MaxHP;
        var currentHp = (float)Stats.CurrentHP;

        return Mathf.FloorToInt((currentHp / maxHp) * 100);
    }

    protected bool IsAlive()
    {
        CheckDeath();
        return _isEntityAlive;
    }

    protected void CheckDeath()
    {
        if (Stats.CurrentHP <= 0) 
        { 
            _isEntityAlive = false;
        }
    }

    protected void Die()
    {
        Destroy(gameObject);
    }

    private float GetDefenseAsDamageMultiplier()
    {
        return 1 - (float)Stats.Defense / 100;
    }

    protected void SetStats(int maxHp, int attackPower, int defense, int critChancePercent)
    {
        Stats.MaxHP = maxHp;
        Stats.AttackPower = attackPower;
        Stats.Defense = defense;
        Stats.CritChancePercent = critChancePercent;
    }

    public void SetStats(Stats stats)
    {
        Stats = stats;
    }
}
