using UnityEngine;

public class PlayerAttackAreaScript : MonoBehaviour
{
    private int _damage;
    private int _critChance;
    private int _critDamage;

    private void Start()
    {
        var playerStats = transform.parent.gameObject.GetComponent<Stats>();
        _damage = playerStats.AttackPower;
        _critChance = playerStats.CritChancePercent;
        _critDamage = playerStats.CritDamageMultiplier * _damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Boss"))
        {
            var enemy = collision.GetComponent<EnemyCombatScript>();
            if (enemy != null)
            {
                var damage = CountDamage();
                enemy.Damage(damage);
            }
            else
            {
                Debug.Log("This enemy is not combat ready yet and cannot be damaged.");
            }
        }
    }

    private int CountDamage()
    {
        var crit = RollForCrit(_critChance);
        var damage = crit ? _critDamage : _damage;

        //temp
        if (crit)
        {
            Debug.Log($"Crit! Dealt {_critDamage} damage.");
        }

        return damage;
    }

    private bool RollForCrit(int critChancePercent)
    {
        var random = new System.Random();
        var roll = random.Next(0, 100);
        if (roll <= critChancePercent)
        {
            return true;
        }
        return false;
    }
}
