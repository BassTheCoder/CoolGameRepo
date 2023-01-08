using UnityEngine;

public class PlayerMovementScript : EntityMovementScript
{
    private void Start()
    {
        GetPhysicsProperties();
    }

    void FixedUpdate()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        GetMoveVector(xAxis, yAxis);
        Move(MoveVector);
    }
}
