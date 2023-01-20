using System;
using UnityEngine;

public class EnemyCombatScript : CombatBase
{
    private GameObject _player = default;

    private bool _isHpBarActive = false;
    private bool _isCollidingWithPlayer = false;
    private float _nextAttackTime = 0;

    void Start()
    {
        GetStats();
        GetPlayerGameObject();
    }

    void FixedUpdate()
    {
        var currentHpPercent = GetCurrentHpPercent();
        if (currentHpPercent < 100 && !_isHpBarActive)
        {
            ActivateHpBar();
        }

        if (!IsAlive())
        {
            Die();
        }

        if (_isCollidingWithPlayer && CanAttackPlayer())
        {
            AttackPlayer();
            DetermineTimeForNextAttack();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isCollidingWithPlayer = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isCollidingWithPlayer = false;
        }
    }

    private void AttackPlayer()
    {
        _player.GetComponent<Stats>().CurrentHP -= Stats.AttackPower;
    }

    private void DetermineTimeForNextAttack()
    {
        _nextAttackTime = Time.timeSinceLevelLoad + Stats.AttackSpeed;
    }

    private bool CanAttackPlayer()
    {
        return Time.timeSinceLevelLoad >= _nextAttackTime;
    }

    public void Damage(int damage)
    {
        GetHitFor(damage);
    }

    private void ActivateHpBar()
    {
        _isHpBarActive = true;
        transform.GetChild(0).gameObject.SetActive(true);
        var children = transform.GetChild(0).gameObject.GetComponentsInChildren<Transform>();
        foreach (var child in children)
        {
            child.gameObject.SetActive(true);
        }
    }

    private void GetPlayerGameObject()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }
}
