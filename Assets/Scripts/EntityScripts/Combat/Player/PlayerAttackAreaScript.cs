using UnityEngine;

public class PlayerAttackAreaScript : MonoBehaviour
{
    private float _attackPower;

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Debug.Log($"{collision.name} has been slain!");
        }
    }
}
