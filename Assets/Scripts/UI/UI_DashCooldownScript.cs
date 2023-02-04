using UnityEngine;

public class UI_DashCooldownScript : MonoBehaviour
{
    private GameObject _player;
    private PlayerMovementScript _playerMovementScript;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerMovementScript = _player.GetComponent<PlayerMovementScript>();
    }


    void Update()
    {
        transform.localScale = new Vector3(1, _playerMovementScript.DashCooldownDelta, 1);
    }
}
