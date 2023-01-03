using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EntityScript : MonoBehaviour
{
    protected BoxCollider2D BoxCollider;
    protected Vector3 MoveVector;

    protected float MovementSpeedMultiplier = 0.75f;

    #region Private Methods
    protected void ResetMoveVector(float x = 0, float y = 0)
    {
        MoveVector = new Vector3(x, y, 0);
    }

    protected void Move(Vector3 moveVector)
    {
        OrientateEntityModelOnMovement(moveVector.x);
        transform.Translate(MovementSpeedMultiplier * Time.deltaTime * moveVector);
    }

    protected void MoveTowards(Transform targetTransform, float step)
    {
        var moveVector = Vector3.MoveTowards(transform.position, targetTransform.position, step);
        OrientateEntityModelOnMovement(moveVector.x);
        transform.position = moveVector;
    }

    private void OrientateEntityModelOnMovement(float x)
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
    #endregion
}
