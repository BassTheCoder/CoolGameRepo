using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EntityStats))]
public class EntityMovementScript : MonoBehaviour
{
    public Animator EntityAnimator;
    public AnimationClip[] PositionFreezingAnimations = null;

    private float _movementSpeedMultiplier;

    protected BoxCollider2D BoxCollider;
    protected Rigidbody2D Rigidbody;
    protected Vector3 MoveVector;

    private RaycastHit2D _raycast;

    #region Methods
    protected void GetPhysicsProperties()
    {
        _movementSpeedMultiplier = GetComponent<EntityStats>().MovementSpeed;
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
        if (CanEntityMove())
        {
            OrientateEntityModelOnMovement(MoveVector.x);
            if (EntityAnimator != null)
            {
                EntityAnimator.SetFloat("Speed", moveVector.sqrMagnitude);
            }

            transform.Translate(_movementSpeedMultiplier * Time.fixedDeltaTime * moveVector);
        }
    }

    private bool CanEntityMove()
    {
        var rewards = GameObject.FindGameObjectWithTag("UI_Rewards");
        GetRaycastHit();
        
        return
            _raycast.collider == null &&
            !IsFreezingAnimationPlaying() &&
            (rewards == null || !rewards.activeSelf);
    }

    private void GetRaycastHit()
    {
        _raycast = Physics2D.BoxCast(
            origin: transform.position, 
            size: BoxCollider.size, 
            angle: 0, 
            direction: new Vector2(MoveVector.x, MoveVector.y), 
            distance: Mathf.Abs(Mathf.Sqrt(Mathf.Abs(MoveVector.x) + Mathf.Abs(MoveVector.y)) * Time.deltaTime), 
            layerMask: LayerMask.GetMask("Construction"));
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
