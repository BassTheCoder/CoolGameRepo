using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    public Animator EntityAnimator = default;
    private GameObject _playerAttackArea = default;

    private bool _canPlayerAttack = true;
    private bool _isPlayerAttacking = false;

    private float _attackTimeWindow = 0.25f;
    private float _attackTimer = 0f;
    private float _attackWindowDelay = 0.1f;


    void Start()
    {
        _playerAttackArea = transform.GetChild(0).gameObject;
        _playerAttackArea.SetActive(false);
    }

    void Update()
    {
        if (_canPlayerAttack && Input.GetKeyDown(Keybinds.Attack))
        {
            Attack();
        }

        if (_isPlayerAttacking)
        {
            OpenAttackWindowAfterDelay(_attackWindowDelay);
            DisablePlayerAttackAction();
            _attackTimer += Time.deltaTime;

            if (_attackTimer >= _attackTimeWindow)
            {
                ResetAttackTimer();
                _isPlayerAttacking = false;
                SetAnimatorAttackingState(_isPlayerAttacking);
                CloseAttackWindow();
                EnablePlayerAttackAction();
            }
        }
    }

    private void Attack()
    {
        _isPlayerAttacking = true;
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
        _playerAttackArea.SetActive(true);
    }

    private void CloseAttackWindow()
    {
        _playerAttackArea.SetActive(false);
    }

    private void DisablePlayerAttackAction()
    {
        _canPlayerAttack = false;
    }

    private void EnablePlayerAttackAction()
    {
        _canPlayerAttack = true;
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
