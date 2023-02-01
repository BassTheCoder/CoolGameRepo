using UnityEngine;

public class ShotScript : MonoBehaviour
{
    public float ShotTravelSpeed = 3f;
    private int _shotDamage = 0;
    public Rigidbody2D RigidBody;
    private int _piercing = 0;
    private int _piercedThrough = 0;

    private void Start()
    {
        _piercing = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().ArrowPiercing;
        RigidBody = GetComponent<Rigidbody2D>();
        RigidBody.velocity = transform.right * ShotTravelSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _shotDamage = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().ShootingPower;
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss"))
        {
            var enemy = collision.gameObject;
            enemy.DamageFor(_shotDamage);

            _piercedThrough++;
            if (_piercedThrough > _piercing)
            {
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Construction"))
        {
            Destroy(gameObject);
        }
    }
}
