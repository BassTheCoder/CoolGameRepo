using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : EntityScript
{
    void Start()
    {
        BoxCollider = GetComponent<BoxCollider2D>();

        MovementColliderLayerNames = new string[] { "Entity", "Construction" };
    }


    void FixedUpdate()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        ResetMoveVector(xAxis, yAxis);

        OrientateEntityModelOnMovement(MoveVector.x);

        Move(MoveVector);
    }
}
