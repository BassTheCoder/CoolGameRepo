using UnityEngine;

public class ElementalScript : EnemyMovementScript
{
    void Start()
    {
        GetPhysicsProperties();
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
        IsModelReversed = true;
        FollowPlayer = PlayerObject != null;

        MovementSpeedMultiplier = 0.5f;
    }
}
