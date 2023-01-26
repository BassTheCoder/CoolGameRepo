using TMPro;
using UnityEngine;

public class UI_Ammo : MonoBehaviour
{
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (_player != null)
        {
            GetComponent<TextMeshProUGUI>().text = _player.GetComponent<Stats>().Ammo.ToString();
        }
    }
}
