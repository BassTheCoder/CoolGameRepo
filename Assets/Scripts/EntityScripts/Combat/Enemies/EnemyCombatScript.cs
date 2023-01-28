using UnityEngine;

public class EnemyCombatScript : CombatBase
{
    public Animator EntityAnimator = null;
    private GameObject _player = default;
    protected float AttackDelayFrames = 20;

    private bool _isHpBarActive = false;
    private bool _isCollidingWithPlayer = false;
    private float _nextAttackTime = 0;
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
            _collisionFrames >= AttackDelayFrames &&
            Time.time >= _nextAttackTime;
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
