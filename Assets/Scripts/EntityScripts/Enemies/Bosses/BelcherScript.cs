using UnityEngine;

public class BelcherScript : EnemyMovementScript
{
    void Start()
    {
        GetPhysicsProperties();
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
        IsModelReversed = true;
        FollowPlayer = PlayerObject != null;

        MovementSpeedMultiplier = 0.3f;
    }
}