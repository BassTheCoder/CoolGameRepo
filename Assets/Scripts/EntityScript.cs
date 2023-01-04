using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class EntityScript : MonoBehaviour
{
    protected BoxCollider2D BoxCollider;
    protected Rigidbody2D Rigidbody;
    protected Vector3 MoveVector;

    protected float MovementSpeedMultiplier = 0.75f;

    #region Private Methods
    protected void ResetMoveVector(float x = 0, float y = 0)
    {
        MoveVector = new Vector3(x, y, 0);
    }

    protected void Move(Vector3 moveVector)
    {
        transform.Translate(MovementSpeedMultiplier * Time.deltaTime * moveVector);
    }

    protected void OrientateEntityModelOnMovement(float x, bool isReversed = false)
    {
        if (isReversed)
        {
            if (x > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (x < 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
            if (x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
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

    protected void ResetFreeze()
    {
        Rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    #endregion
}
