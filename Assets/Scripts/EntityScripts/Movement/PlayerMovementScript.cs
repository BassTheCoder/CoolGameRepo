using UnityEngine;

public class PlayerMovementScript : EntityMovementScript
{
    private void Start()
    {
        GetPhysicsProperties();
        MovementSpeedMultiplier = 0.75f;
    }

    void FixedUpdate()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        GetMoveVector(xAxis, yAxis);
        Move(MoveVector);
    }
}
