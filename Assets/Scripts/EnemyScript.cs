using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : EntityScript
{
    private GameObject _player;

    void Start()
    {
        BoxCollider = GetComponent<BoxCollider2D>();
        MovementSpeedMultiplier = 0.3f;
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        var step = Time.deltaTime * MovementSpeedMultiplier;

        MoveTowards(_player.transform, step);
    }
}
