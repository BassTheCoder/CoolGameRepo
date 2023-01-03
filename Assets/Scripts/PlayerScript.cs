using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerScript : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    private Vector3 _moveDelta;

    void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }


    void FixedUpdate()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        ResetMoveVector(xAxis, yAxis);

        OrientatePlayerModelOnMovement(_moveDelta.x);

        MovePlayer(_moveDelta);
    }

    private void ResetMoveVector(float x, float y)
    {
        _moveDelta = new Vector3(x, y, 0);
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

    private void MovePlayer(Vector3 vector)
    {
        transform.Translate(vector * Time.deltaTime);
    }
}
