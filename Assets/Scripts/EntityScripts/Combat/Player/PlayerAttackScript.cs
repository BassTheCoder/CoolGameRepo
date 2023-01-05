using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    public Animator EntityAnimator = default;
    private GameObject _playerAttackArea = default;

    private bool _canPlayerAttack = true;
    private bool _isPlayerAttacking = false;

    private float _attackTimeFrame = 0.25f;
    private float _attackTimer = 0f;


    void Start()
    {
        _playerAttackArea = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (_canPlayerAttack && Input.GetKeyDown(Keybinds.Attack))
        {
            Attack();
        }

        if (_isPlayerAttacking)
        {
            _attackTimer += Time.deltaTime;

            if (_attackTimer >= _attackTimeFrame)
            {
                _attackTimer= 0f;
                _isPlayerAttacking= false;
                SetAnimatorAttackingState(_isPlayerAttacking);
                _playerAttackArea.SetActive(false);
            }
        }
    }

    private void Attack()
    {
        _isPlayerAttacking = true;
        SetAnimatorAttackingState(_isPlayerAttacking);
        _playerAttackArea.SetActive(true);
    }

    private void SetAnimatorAttackingState(bool attackingState)
    {
        if (EntityAnimator != null)
        {
            EntityAnimator.SetBool("IsPlayerAttacking", attackingState);
        }
    }
}
