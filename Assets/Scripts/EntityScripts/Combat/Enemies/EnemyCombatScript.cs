using UnityEngine;

public class EnemyCombatScript : CombatBase
{
    private bool _isHpBarActive = false;
    void Start()
    {
        GetStats();
    }

    void Update()
    {
        if (!IsAlive())
        {
            Die();
        }

        var currentHpPercent = GetCurrentHpPercent();
        if (currentHpPercent < 100 && !_isHpBarActive)
        {
            ActivateHpBar();
        }
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
}
