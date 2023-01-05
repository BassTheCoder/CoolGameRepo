using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    public Animator EntityAnimator = default;
    private GameObject _playerAttackArea = default;

    private bool _canPlayerAttack = true;
    private bool _isPlayerAttacking = false;

    private float _attackTimeWindow = 0.25f;
    private float _attackTimer = 0f;


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
            DisablePlayerAttackAction();
            _attackTimer += Time.deltaTime;

            if (_attackTimer >= _attackTimeWindow)
            {
                _attackTimer= 0f;
                _isPlayerAttacking= false;
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
        OpenAttackWindowAfterDelay(0f);
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

    private void SetAnimatorAttackingState(bool attackingState)
    {
        if (EntityAnimator != null)
        {
            EntityAnimator.SetBool("IsPlayerAttacking", attackingState);
        }
    }
}
