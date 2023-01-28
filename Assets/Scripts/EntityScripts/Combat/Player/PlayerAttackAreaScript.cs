using UnityEngine;

public class PlayerAttackAreaScript : AttackAreaScript
{
    private void Start()
    {
        InitiateStats();
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
                Debug.Log("This is not an enemy, therefore cannot be damaged.");
            }
        }
    }

}
