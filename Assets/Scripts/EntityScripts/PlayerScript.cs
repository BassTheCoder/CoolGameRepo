using UnityEngine;

public class PlayerScript : EntityScript
{
    void Start()
    {
        BoxCollider = GetComponent<BoxCollider2D>();
        Rigidbody= GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        ResetMoveVector(xAxis, yAxis);
        OrientateEntityModelOnMovement(xAxis);
        Move(MoveVector);
    }
}
