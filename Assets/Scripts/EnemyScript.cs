using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : EntityScript
{
    private GameObject _player;
    private bool _isCollidingWithPlayer;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        BoxCollider = GetComponent<BoxCollider2D>();
        MovementSpeedMultiplier = 0.3f;
    }

    void FixedUpdate()
    {
        var step = Time.deltaTime * MovementSpeedMultiplier;

        if (!_isCollidingWithPlayer)
        {
            MoveTowards(_player.transform, step);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _isCollidingWithPlayer = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isCollidingWithPlayer = false;
    }
}
