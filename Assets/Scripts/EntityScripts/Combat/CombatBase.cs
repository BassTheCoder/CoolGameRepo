using UnityEngine;

[RequireComponent(typeof(Stats))]
public class CombatBase : MonoBehaviour
{
    protected Stats Stats;

    private bool _isEntityAlive = true;

    private void Update()
    {
        CheckDeath();
        if (!_isEntityAlive)
        {
            Die();
        }
    }

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
        Stats.CurrentHP -= damage;
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
}
