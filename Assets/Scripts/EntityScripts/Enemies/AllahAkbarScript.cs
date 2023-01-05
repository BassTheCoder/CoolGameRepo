using System;
using UnityEngine;

public class AllahAkbarScript : EnemyMovementScript
{
    void Start()
    {
        GetPhysicsProperties();
        gameObject.tag = "TouchKiller";
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
        IsModelReversed = true;
        FollowPlayer = PlayerObject != null;

        MovementSpeedMultiplier = 0.8f;
    }

    void Update()
    {
        if (IsCollidingWithPlayer)
        {
            ExecuteOrder66();
        }
    }

    private void ExecuteOrder66()
    {
        Destroy(gameObject);
        Destroy(PlayerObject);
    }
}
