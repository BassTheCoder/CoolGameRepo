using UnityEngine;

public class EnemyMovementScript : EntityMovementScript
{
    protected Transform PlayerObjectTransform;
    protected bool IsCollidingWithPlayer = false;
    
    public bool FollowPlayer = true;

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
                MoveVector = GetNormalizedVectorTowardsTarget(PlayerObjectTransform);
                Move(MoveVector);
            }
        }
        else
        {
            TryStartFollowingPlayer();
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

    protected void GetPlayerObjectTransform()
    {
        PlayerObjectTransform = GetPlayerObject().transform;
    }

    protected void DoNotFollowIfTheresNoPlayer()
    {
        if (FollowPlayer && GetPlayerObject() == null)
        {
            FollowPlayer = false;
        }
    }

    private void TryStartFollowingPlayer()
    {
        if (!FollowPlayer && GetPlayerObject() != null)
        {
            FollowPlayer = true;
        }
    }

    private GameObject GetPlayerObject()
    {
        return GameObject.FindGameObjectWithTag("Player");
    }
}
