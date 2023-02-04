using UnityEngine;

[RequireComponent(typeof(EntityStats))]
public class CombatBase : MonoBehaviour
{
    protected EntityStats Stats;

    private bool _isEntityAlive = true;

    protected virtual void GetStats()
    {
        Stats = gameObject.GetComponentInParent<EntityStats>();
    }

    protected bool IsAlive()
    {
        CheckDeath();
        return _isEntityAlive;
    }

    protected void CheckDeath()
    {
        if (gameObject.GetCurrentHp() <= 0) 
        { 
            _isEntityAlive = false;
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    public void SetStats(EntityStats stats)
    {
        Stats = stats;
    }
}
