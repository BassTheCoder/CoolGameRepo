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
        transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(true);

        //GameObject hpBarElement = transform.Find("HpBar")?.gameObject;
        //if (hpBarElement != null)
        //{
        //    hpBarElement.SetActive(true);

        //    GameObject hpBarBackground = transform.Find("BarBackground")?.gameObject;
        //    if (hpBarBackground != null)
        //    {
        //        hpBarBackground.SetActive(true);
        //    }

        //    GameObject barAnchor = transform.Find("BarAnchor")?.gameObject;
        //    if (barAnchor != null)
        //    {
        //        barAnchor.SetActive(true);

        //        GameObject barSprite = transform.Find("BarSprite")?.gameObject;
        //        if (barSprite != null)
        //        {
        //            barSprite.SetActive(true);
        //        }
        //    }
        //    _isHpBarActive = true;
        //}
    }
}
