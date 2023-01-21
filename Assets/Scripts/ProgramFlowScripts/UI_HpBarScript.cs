using UnityEngine;

public class UI_HpBarScript : MonoBehaviour
{
    public GameObject Entity = null;
    public Material DamageBlinkMaterial = null;

    private float _oldHp;
    private Material _defaultEntityRendererMaterial = default;

    private bool _isBlinking = false;
    private int _currentBlinkFrames = 0;
    private int _blinkFrames = 45;

    private void Start()
    {
        if (Entity == null)
        {
            Debug.Log("Sctipt has no entity given to track health!");
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
            if (_isBlinking && _currentBlinkFrames >= _blinkFrames)
            {
                Entity.GetComponent<SpriteRenderer>().material = _defaultEntityRendererMaterial;
                _isBlinking = false;
                _currentBlinkFrames = 0;
            }
            else if (_isBlinking)
            {
                _currentBlinkFrames++;
            }

            var currentHpPercent = Entity.GetEntityCurrentHpPercent();
            if (currentHpPercent < _oldHp && DamageBlinkMaterial != null)
            {
                Entity.GetComponent<SpriteRenderer>().material = DamageBlinkMaterial;
                _isBlinking = true;
            }
            transform.GetChild(2).gameObject.transform.localScale = new Vector3(currentHpPercent, 1, 1);
            _oldHp = currentHpPercent;
        }
    }
}
