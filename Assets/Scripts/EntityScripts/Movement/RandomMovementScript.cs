using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovementScript : EntityMovementScript
{
    private float _whenUpdateDirection;
    private int _randomDirectionUpdateTimeInSeconds = 1;
    private void Start()
    {
        GetPhysicsProperties();
    }

    private void FixedUpdate()
    {
        if (ShouldUpdateDirection())
        {
            GetNewRandomMoveVector();
            UpdateDirectionChangeTime();
        }

        Move(MoveVector);
    }

    private bool ShouldUpdateDirection()
    {
        return _whenUpdateDirection == Time.timeSinceLevelLoad;
    }

    private void GetNewRandomMoveVector()
    {
        var random = new System.Random();
        GetMoveVector(GetRandomFloatForMoveVector(), GetRandomFloatForMoveVector());
        MoveVector.Normalize();

        float GetRandomFloatForMoveVector(float min = -1f, float max = 1f)
        {
            return (float)(random.NextDouble() * (max - min) + min);
        }
    }

    private void UpdateDirectionChangeTime()
    {
        _randomDirectionUpdateTimeInSeconds = (int)Mathf.Floor(Random.value * 3);
        _whenUpdateDirection = Time.timeSinceLevelLoad + _randomDirectionUpdateTimeInSeconds;
    }
}
