using UnityEngine;

public class EnemyCombatScript : CombatBase
{
    public Animator EntityAnimator = null;
    private GameObject _player = default;

    private bool _isHpBarActive = false;
    private bool _isCollidingWithPlayer = false;
    private float _nextAttackTime = 0;
    private float _attackDelayFrames = 10;
    private int _collisionFrames = 0;

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
            ReplenishPlayerAmmo();
        }

        if (_isCollidingWithPlayer)
        {
            _collisionFrames++;

            if (CanAttackPlayer())
            {
                AttackPlayer();
                DetermineTimeForNextAttack();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isCollidingWithPlayer = true;
            UpdateAnimatorCollisionProperty(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _collisionFrames = 0;
            _isCollidingWithPlayer = false;
            UpdateAnimatorCollisionProperty(false);
        }
    }

    private void UpdateAnimatorCollisionProperty(bool isColliding)
    {
        if (EntityAnimator != null)
        {
            EntityAnimator.SetBool("IsCollidingWithPlayer", isColliding);
        }
    }

    private void AttackPlayer()
    {
        _player.GetComponent<Stats>().CurrentHP -= Stats.AttackPower;
    }

    private void DetermineTimeForNextAttack()
    {
        var now = Time.time;
        _nextAttackTime = now + Stats.AttackSpeed;
    }

    private bool CanAttackPlayer()
    {
        return
            _collisionFrames >= _attackDelayFrames &&
            Time.time >= _nextAttackTime;
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

    private void ReplenishPlayerAmmo() 
    {
        _player.GetComponent<Stats>().Ammo = _player.GetComponent<Stats>().MaxAmmo;
    }

    private void GetPlayerGameObject()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }
}
