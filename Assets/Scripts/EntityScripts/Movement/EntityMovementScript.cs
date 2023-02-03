using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class EntityMovementScript : MonoBehaviour
{
    public Animator EntityAnimator;
    public AnimationClip[] PositionFreezingAnimations = null;

    protected BoxCollider2D BoxCollider;
    protected Rigidbody2D Rigidbody;
    protected Vector3 MoveVector;

    public float MovementSpeedMultiplier = 0.5f;

    #region Methods
    protected void GetPhysicsProperties()
    {
        BoxCollider = GetComponent<BoxCollider2D>();
        Rigidbody = GetComponent<Rigidbody2D>();
        Rigidbody.gravityScale = 0;
    }

    protected void GetMoveVector(float x = 0, float y = 0)
    {
        MoveVector = new Vector3(x, y, 0);
        if (Mathf.Abs(MoveVector.x) == 1 && Mathf.Abs(MoveVector.y) == 1)
        {
            MoveVector = 0.72f * MoveVector;
        }
    }

    protected void Move(Vector3 moveVector)
    {
        if (CanPlayerMove())
        {
            OrientateEntityModelOnMovement(MoveVector.x);
            if (EntityAnimator != null)
            {
                EntityAnimator.SetFloat("Speed", moveVector.sqrMagnitude);
            }

            transform.Translate(MovementSpeedMultiplier * Time.fixedDeltaTime * moveVector);
        }
    }

    private bool CanPlayerMove()
    {
        var rewards = GameObject.FindGameObjectWithTag("UI_Rewards");

        return
            !IsFreezingAnimationPlaying() &&
            (rewards == null || !rewards.activeSelf);
    }

    protected void OrientateEntityModelOnMovement(float x)
    {
        if (x > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
        }
        else if (x < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
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

    private bool IsFreezingAnimationPlaying()
    {
        if (PositionFreezingAnimations != null && PositionFreezingAnimations.Length > 0)
        {
            return PositionFreezingAnimations.Any(animation => EntityAnimator.GetCurrentAnimatorStateInfo(0).IsName(animation.name));
        }
        return false;
    }
    #endregion
}
