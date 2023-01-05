using UnityEngine;

public class EnemyMovementScript : EntityMovementScript
{
    protected GameObject PlayerObject;
    protected bool IsCollidingWithPlayer;

    public bool FollowPlayer = true;

    void Start()
    {
        GetPhysicsProperties();
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
        MovementSpeedMultiplier = 0.3f;
        IsModelReversed = true;
    }

    void FixedUpdate()
    {
        if (FollowPlayer)
        {
            if (IsCollidingWithPlayer)
            {
                FreezePosition();
            }
            else
            {
                UnfreezePosition();
                MoveVector = GetNormalizedVectorTowardsTarget(PlayerObject.transform);
                Move(MoveVector);
            }
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
