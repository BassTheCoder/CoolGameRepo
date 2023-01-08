using UnityEngine;

public class PlayerCombatScript : CombatBase
{
    public Animator EntityAnimator = default;
    private GameObject _attackArea;

    private bool _isPlayerAttacking = false;

    private float _attackTimeWindow = 0.25f;
    private float _attackTimer = 0f;

    void Start()
    {
        GetStats();
        _attackArea = transform.GetChild(0).gameObject;
        _attackArea.SetActive(false);
    }

    void Update()
    {
        if (!_isPlayerAttacking && Input.GetKeyDown(Keybinds.Attack))
        {
            Attack();
        }

        if (_isPlayerAttacking)
        {
            _attackTimer += Time.deltaTime;

            if (_attackTimer >= _attackTimeWindow)
            {
                ResetAttackTimer();
                _isPlayerAttacking = false;
                SetAnimatorAttackingState(_isPlayerAttacking);
                CloseAttackWindow();
            }
        }
    }

    private void Attack()
    {
        _isPlayerAttacking = true;
        OpenAttackWindow();
        SetAnimatorAttackingState(_isPlayerAttacking);
    }

    private void OpenAttackWindowAfterDelay(float delay)
    {
        if (_attackTimer >= delay)
        {
            OpenAttackWindow();
        }
    }

    private void OpenAttackWindow()
    {
        if (_isPlayerAttacking && _attackArea != null)
        {
            _attackArea.SetActive(true);
        }
    }

    private void CloseAttackWindow()
    {
        if (_attackArea != null)
        {
            _attackArea.SetActive(false);
        }
    }

    private void ResetAttackTimer()
    {
        _attackTimer = 0f;
    }

    private void SetAnimatorAttackingState(bool attackingState)
    {
        if (EntityAnimator != null)
        {
            EntityAnimator.SetBool("IsPlayerAttacking", attackingState);
        }
    }
}
