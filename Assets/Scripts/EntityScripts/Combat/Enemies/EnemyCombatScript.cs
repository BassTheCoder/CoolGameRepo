using TMPro;
using UnityEngine;

public class EnemyCombatScript : CombatBase
{
    public Animator EntityAnimator = null;
    private GameObject _player = default;
    protected float AttackDelayFrames = 20;

    private bool _isHpBarActive = false;

    void Start()
    {
        GetStats();
        GetPlayerGameObject();
    }

    void FixedUpdate()
    {
        var currentHpPercent = gameObject.GetCurrentHpPercent();
        if (currentHpPercent < 100 && !_isHpBarActive)
        {
            ActivateHpBar();
        }

        if (!IsAlive())
        {
            Die();
            ReplenishPlayerAmmo();
            UpdateEnemyCounter();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UpdateAnimatorCollisionProperty(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
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
        _player.RefillAmmo();
    }

    private void UpdateEnemyCounter()
    {
        var enemyCounter = GameObject.FindGameObjectWithTag("UI_EnemyCounter");
        if (enemyCounter != null)
        {
            var textElement = enemyCounter.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            textElement.text = (int.Parse(textElement.text) - 1).ToString();
        }
    }

    private void GetPlayerGameObject()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }
}
