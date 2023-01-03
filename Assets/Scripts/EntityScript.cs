using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EntityScript : MonoBehaviour
{
    protected BoxCollider2D BoxCollider;
    protected RaycastHit2D RaycastHit;
    protected Vector3 MoveVector;

    protected string[] MovementColliderLayerNames = Array.Empty<string>();
    protected float MovementSpeedMultiplier = 0.75f;

    #region Private Methods
    protected void ResetMoveVector(float x = 0, float y = 0)
    {
        MoveVector = new Vector3(x, y, 0);
    }

    protected void OrientateEntityModelOnMovement(float x)
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

    protected void Move(Vector3 moveVector)
    {
        CheckCollisionForCurrentMovementDirection(moveVector);
        if (RaycastHit.collider == null)
        {
            transform.Translate(MovementSpeedMultiplier * Time.deltaTime * moveVector);
        }
    }

    private void CheckCollisionForCurrentMovementDirection(Vector3 moveVector)
    {
        RaycastHit = Physics2D.BoxCast(
            origin: transform.position,
            size: BoxCollider.size,
            angle: 0,
            direction: new Vector2(moveVector.x, moveVector.y),
            distance: GetMovementDistanceForNextFrame(moveVector),
            layerMask: LayerMask.GetMask(MovementColliderLayerNames)
            );
    }

    private float GetMovementDistanceForNextFrame(Vector3 moveVector)
    {
        float xDistance = GetMovementDistanceForDirection(moveVector.x);
        float yDistance = GetMovementDistanceForDirection(moveVector.y);

        var result = Mathf.Sqrt(Mathf.Pow(xDistance, 2) + Mathf.Pow(yDistance, 2));

        return result;

        float GetMovementDistanceForDirection(float vector)
        {
            return Mathf.Abs(MovementSpeedMultiplier * Time.deltaTime * vector);
        }
    }
    #endregion
}
