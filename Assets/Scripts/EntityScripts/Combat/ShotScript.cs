using UnityEngine;

public class ShotScript : MonoBehaviour
{
    public float ShotTravelSpeed = 3f;
    private int _shotDamage = 0;
    public Rigidbody2D RB;

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        RB.velocity = transform.right * ShotTravelSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _shotDamage = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>().ShootingPower;
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss"))
        {
            var enemy = collision.gameObject.GetComponent<EnemyCombatScript>();
            enemy.Damage(_shotDamage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Construction"))
        {
            Destroy(gameObject);
        }
    }
}
