using System.Collections;
using System.Collections.Generic;
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
            var player = collision.GetComponent<PlayerCombatScript>();
            if (player != null)
            {
                var damage = CountDamage();
                player.Damage(damage);
            }
        }
    }
}
