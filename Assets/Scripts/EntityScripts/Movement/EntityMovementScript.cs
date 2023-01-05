using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class EntityMovementScript : MonoBehaviour
{
    public Animator EntityAnimator;

    protected GameObject Self;
    protected BoxCollider2D BoxCollider;
    protected Rigidbody2D Rigidbody;
    protected Vector3 MoveVector;

    protected bool IsModelReversed = false;

    protected float MovementSpeedMultiplier = 0.5f;

    private void Start()
    {
        UnfreezePosition();
    }

    #region Methods
    protected void GetPhysicsProperties()
    {
        Self = GetComponent<GameObject>();
        BoxCollider = GetComponent<BoxCollider2D>();
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    protected void GetMoveVector(float x = 0, float y = 0)
    {
        MoveVector = new Vector3(x, y, 0);
    }

    protected void Move(Vector3 moveVector)
    {
        OrientateEntityModelOnMovement(MoveVector.x);

        if (EntityAnimator != null)
        {
            EntityAnimator.SetFloat("Speed", moveVector.sqrMagnitude);
        }

        transform.Translate(MovementSpeedMultiplier * Time.fixedDeltaTime * moveVector);
    }

    protected void OrientateEntityModelOnMovement(float x)
    {
        if (x > 0)
        {
            transform.localScale = new Vector3(IsModelReversed ? -1 : 1, 1, 1);
        }
        else if (x < 0)
        {
            transform.localScale = new Vector3(IsModelReversed ? 1 : -1, 1, 1);
        }

    }

    protected Vector3 GetNormalizedVectorTowardsTarget(Transform targetTransform)
    {
        return (targetTransform.position - transform.position).normalized;
    }

    protected void FreezePosition()
    {
        Rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    protected void UnfreezePosition()
    {
        Rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    #endregion
}
