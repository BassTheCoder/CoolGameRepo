using UnityEngine;

public class UI_HpBarScript : MonoBehaviour
{
    public GameObject Entity = null;
    public Material DamageBlinkMaterial = null;

    private float _oldHp;
    private Material _defaultEntityRendererMaterial = default;

    private bool _isBlinking = false;
    private float _blinkingStopTime = 0;
    private float _howLongShouldBlink = 0.2f;

    private void Start()
    {
        if (Entity == null)
        {
            Debug.Log("Script has no entity given to track health!");
        }
        else
        {
            _defaultEntityRendererMaterial = Entity.GetComponent<SpriteRenderer>().material;
        }
    }

    void Update()
    {
        if (Entity != null)
        {
            if (_isBlinking && Time.time >= _blinkingStopTime)
            {
                Entity.GetComponent<SpriteRenderer>().material = _defaultEntityRendererMaterial;
                _isBlinking = false;
            }

            var currentHpPercent = Entity.GetCurrentHpDecimal();
            if (currentHpPercent < _oldHp && DamageBlinkMaterial != null)
            {
                Entity.GetComponent<SpriteRenderer>().material = DamageBlinkMaterial;
                _isBlinking = true;
                _blinkingStopTime = Time.time + _howLongShouldBlink;
            }
            transform.GetChild(2).gameObject.transform.localScale = new Vector3(currentHpPercent, 1, 1);
            _oldHp = currentHpPercent;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
