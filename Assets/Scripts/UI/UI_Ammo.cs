using TMPro;
using UnityEngine;

public class UI_Ammo : MonoBehaviour
{
    private GameObject _player;
    private TextMeshProUGUI _textMeshPro;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        if (_player != null)
        {
            GetComponent<TextMeshProUGUI>().text = _player.GetComponent<PlayerStats>().Ammo.ToString();
        }

        GetTextColor();
    }

    private void GetTextColor()
    {
        if (int.Parse(_textMeshPro.text) <= 10)
        {
            _textMeshPro.color = Color.white;
        }
        if (int.Parse(_textMeshPro.text) <= 5)
        {
            _textMeshPro.color = Color.yellow;
        }
        if (int.Parse(_textMeshPro.text) <= 3)
        {
            _textMeshPro.color = new Color32(255, 90, 0, 255);
        }
        if (int.Parse(_textMeshPro.text) <= 0)
        {
            _textMeshPro.color = Color.red;
        }
        
    }
}
