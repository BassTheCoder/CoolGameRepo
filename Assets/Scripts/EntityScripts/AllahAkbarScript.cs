using System;
using UnityEngine;

public class AllahAkbarScript : EnemyMovementScript
{
    void Start()
    {
        GetPhysicsProperties();
        GetPlayerObjectTransform();

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
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }
}
