using UnityEngine;

public class ShowHP : MonoBehaviour
{
    private GameObject _character;
    private Stats _characterStats;
    private float _hp;
    private float _hpPercent;
    // Start is called before the first frame update
    void Start()
    {
        _character = gameObject.transform.parent.parent.gameObject;
        _characterStats = _character.GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        GetHp();
        GetHpPercent();
        gameObject.transform.localScale = new Vector3(_hpPercent, 1, 1);
    }

    private void GetHp()
    {
        _hp = _character.GetComponent<Stats>().CurrentHP;
    }

    private void GetHpPercent()
    {
        _hpPercent = (_hp / _characterStats.MaxHP);
    }
}
