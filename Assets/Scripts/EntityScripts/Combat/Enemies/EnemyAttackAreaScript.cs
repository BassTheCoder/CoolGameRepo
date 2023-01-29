using UnityEngine;

public class EnemyAttackAreaScript : AttackAreaScript
{
    void Start()
    {
        InitiateStats();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DealDamage(collision);
        }
    }

    protected void DealDamage(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerCombatScript>();
        if (player != null)
        {
            var damage = CountDamage();
            player.Damage(damage);
        }
    }
}
