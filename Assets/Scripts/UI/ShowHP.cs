using UnityEngine;

public class ShowHP : MonoBehaviour
{
    private GameObject _character;
    private EntityStats _characterStats;
    private float _hp;
    private float _hpPercent;
    
    void Start()
    {
        _character = gameObject.transform.parent.parent.gameObject;
        _characterStats = _character.GetComponent<EntityStats>();
        GetHpValues();
        if (_hpPercent == 1)
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        GetHpValues();
        gameObject.transform.localScale = new Vector3(_hpPercent, 1, 1);
    }

    private void GetHpValues()
    {
        GetHp();
        GetHpPercent();
    }

    private void GetHp()
    {
        _hp = _character.GetComponent<EntityStats>().CurrentHP;
    }

    private void GetHpPercent()
    {
        _hpPercent = (_hp / _characterStats.MaxHP);
    }
}
