using UnityEngine;

public class EnemyScript : EntityScript
{
    protected GameObject PlayerObject;
    protected bool IsCollidingWithPlayer;

    void Start()
    {
        BoxCollider = GetComponent<BoxCollider2D>();
        Rigidbody = GetComponent<Rigidbody2D>();
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
        MovementSpeedMultiplier = 0.3f;
        IsModelReversed = true;
    }

    void FixedUpdate()
    {
        if (IsCollidingWithPlayer)
        {
            FreezePosition();
        }
        else
        {
            ResetFreeze();
            MoveVector = GetNormalizedVectorTowardsTarget(PlayerObject.transform);
            OrientateEntityModelOnMovement(MoveVector.x);
            Move(MoveVector);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsCollidingWithPlayer = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        IsCollidingWithPlayer = false;
    }
}
