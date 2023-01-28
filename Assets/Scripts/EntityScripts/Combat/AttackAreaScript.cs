using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AttackAreaScript : MonoBehaviour
{
    protected int Damage;
    protected int CritChance;
    protected int CritDamage;

    protected void InitiateStats()
    {
        var parentStats = transform.parent.gameObject.GetComponent<Stats>();
        Damage = parentStats.AttackPower;
        CritChance = parentStats.CritChancePercent;
        CritDamage = parentStats.CritDamageMultiplier * Damage;
    }

    protected int CountDamage()
    {
        var crit = RollForCrit(CritChance);
        var damage = crit ? CritDamage : Damage;

        //temp
        if (crit)
        {
            Debug.Log($"Crit! Dealt {CritDamage} damage.");
        }

        return damage;
    }

    private bool RollForCrit(int critChancePercent)
    {
        var random = new System.Random();
        var roll = random.Next(0, 100);
        return roll <= critChancePercent;
    }
}
