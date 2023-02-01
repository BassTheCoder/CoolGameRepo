using UnityEngine;

public class PlayerAttackAreaScript : AttackAreaScript
{
    private void Start()
    {
        InitiateStats();
    }

    protected override void InitiateStats()
    {
        var parentStats = transform.parent.gameObject.GetComponent<PlayerStats>();
        Damage = parentStats.AttackPower;
        CritChance = parentStats.CritChancePercent;
        CritDamage = parentStats.CritDamageMultiplier * Damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Boss"))
        {
            var enemy = collision.gameObject;
            if (enemy != null)
            {
                var damage = CountDamage();
                enemy.DamageFor(damage);
            }
        }
    }
}
