using UnityEngine;

public class PlayerAttackAreaScript : AttackAreaScript
{
    private PlayerStats _stats;
    private void Start()
    {
        _stats = transform.parent.gameObject.GetComponent<PlayerStats>();
        InitiateStats();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Boss"))
        {
            GetWeaponDamage();
            var enemy = collision.gameObject;
            if (enemy != null)
            {
                var damage = CountDamage();
                enemy.DamageFor(damage);
            }
        }
    }

    protected override void InitiateStats()
    {
        GetWeaponDamage();
        CritChance = _stats.CritChancePercent;
        CritDamage = _stats.CritDamageMultiplier * Damage;
    }

    private void GetWeaponDamage()
    {
        var activeWeapon = transform.parent.gameObject.GetComponent<PlayerCombatScript>().ActiveWeapon;
        if (activeWeapon == 1)
        {
            Damage = _stats.AttackPower;
        }
        else if (activeWeapon == 2)
        {
            Damage = _stats.AxeAttackPower;
        }
        else if (activeWeapon == 3)
        {
            Damage = _stats.HammerAttackPower;
        }
    }
}
