using UnityEngine;

public class EnemyMovementScript : EntityMovementScript
{
    protected GameObject PlayerObject;
    protected bool IsCollidingWithPlayer = false;
    
    public bool FollowPlayer = true;

    private void Start()
    {
        IsModelReversed = true;
        MovementSpeedMultiplier = 0.5f;
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
