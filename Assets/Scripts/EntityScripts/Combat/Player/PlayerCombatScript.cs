using UnityEngine;

public class PlayerCombatScript : CombatBase
{
    public bool CanPlayerAttack = true;
    public Animator EntityAnimator = default;
    private GameObject _attackArea;
    public int ActiveWeapon = 1;

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
        if (!IsAlive())
        {
            Die();
        }

        if (WeaponSwitchPressed())
        {
            SwitchWeapon();
        }

        if (!_isPlayerAttacking && Input.GetKeyDown(Keybinds.AttackMelee) && CanPlayerAttack)
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

    private bool WeaponSwitchPressed()
    {
        if (Input.GetKeyDown(Keybinds.Weapon1))
        {
            ActiveWeapon = 1;
            return true;
        }
        else if (Input.GetKeyDown(Keybinds.Weapon2))
        {
            ActiveWeapon = 2;
            return true;
        }
        else if (Input.GetKeyDown(Keybinds.Weapon3))
        {
            ActiveWeapon = 3;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SwitchWeapon()
    {
        if (ActiveWeapon == 1)
        {
            GameObject.FindGameObjectWithTag("SwordSprite").GetComponent<WeaponSpriteScript>().Activate();
            GameObject.FindGameObjectWithTag("AxeSprite").GetComponent<WeaponSpriteScript>().Deactivate();
            GameObject.FindGameObjectWithTag("HammerSprite").GetComponent<WeaponSpriteScript>().Deactivate();
        }
        else if (ActiveWeapon == 2)
        {
            GameObject.FindGameObjectWithTag("SwordSprite").GetComponent<WeaponSpriteScript>().Deactivate();
            GameObject.FindGameObjectWithTag("AxeSprite").GetComponent<WeaponSpriteScript>().Activate();
            GameObject.FindGameObjectWithTag("HammerSprite").GetComponent<WeaponSpriteScript>().Deactivate();
        }
        else if (ActiveWeapon == 3)
        {
            GameObject.FindGameObjectWithTag("SwordSprite").GetComponent<WeaponSpriteScript>().Deactivate();
            GameObject.FindGameObjectWithTag("AxeSprite").GetComponent<WeaponSpriteScript>().Deactivate();
            GameObject.FindGameObjectWithTag("HammerSprite").GetComponent<WeaponSpriteScript>().Activate();
        }
    }
}
