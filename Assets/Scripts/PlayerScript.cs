using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerScript : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    private RaycastHit2D _raycastHit;
    private Vector3 _moveVector;

    private static float _movementMultiplier = 0.5f;

    void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }


    void FixedUpdate()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        ResetMoveVector(xAxis, yAxis);

        OrientatePlayerModelOnMovement(_moveVector.x);

        CheckRaycastHitForCurrentMovementDirection(_moveVector);

        MovePlayer(_moveVector);
    }

    #region Private Methods
    private void ResetMoveVector(float x, float y)
    {
        _moveVector = new Vector3(x, y, 0);
    }

    private void OrientatePlayerModelOnMovement(float x)
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

    private void CheckRaycastHitForCurrentMovementDirection(Vector3 moveVector)
    {
        _raycastHit = Physics2D.BoxCast(
            origin: transform.position, 
            size: _boxCollider.size, 
            angle: 0, 
            direction: new Vector2(moveVector.x, moveVector.y), 
            distance: GetMovementDistanceForNextFrame(moveVector), 
            layerMask: LayerMask.GetMask("Entity", "Construction")
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
            return Mathf.Abs(_movementMultiplier * Time.deltaTime * vector);
        }
    }

    private void MovePlayer(Vector3 moveVector)
    {
        if (_raycastHit.collider == null)
        {
            transform.Translate(_movementMultiplier * Time.deltaTime * moveVector);
        }
    }
    #endregion
}
