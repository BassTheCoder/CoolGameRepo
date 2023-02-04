using UnityEngine;

public class EnemyMovementScript : EntityMovementScript
{
    protected Transform PlayerObjectTransform;
    protected bool IsCollidingWithPlayer = false;

    public bool ShouldFollowPlayer = true;

    private bool _followingPlayer = true;

    private void Start()
    {
        GetPhysicsProperties();
        GetPlayerObjectTransform();
        DoNotFollowIfTheresNoPlayer();
    }

    void FixedUpdate()
    {
        if (ShouldFollowPlayer && PlayerObjectTransform != null)
        {
            if (_followingPlayer)
            {
                if (!IsCollidingWithPlayer)
                {
                    MoveVector = GetNormalizedVectorTowardsTarget(PlayerObjectTransform);
                    Move(MoveVector);
                }
            }
            else
            {
                TryStartFollowingPlayer();
            }
        }
        else
        {
            FreezePosition();
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
        if (_followingPlayer && GetPlayerObject() == null)
        {
            _followingPlayer = false;
        }
    }

    private void TryStartFollowingPlayer()
    {
        if (!_followingPlayer && GetPlayerObject() != null)
        {
            _followingPlayer = true;
        }
    }

    private GameObject GetPlayerObject()
    {
        return GameObject.FindGameObjectWithTag("Player");
    }
}
