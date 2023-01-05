using UnityEngine;

public class DefaultEnemyScript : EnemyMovementScript
{
    void Start()
    {
        GetPhysicsProperties();
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
        IsModelReversed = true;
        FollowPlayer = PlayerObject != null;
    }
}
