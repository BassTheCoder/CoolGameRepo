using UnityEngine;

public class BatScript : EnemyMovementScript
{
    void Start()
    {
        GetPhysicsProperties();
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
        IsModelReversed = true;
        FollowPlayer = PlayerObject != null;

        MovementSpeedMultiplier = 0.8f;
    }
}
