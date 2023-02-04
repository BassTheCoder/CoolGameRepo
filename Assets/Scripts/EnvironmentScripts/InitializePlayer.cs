using UnityEngine;

[DefaultExecutionOrder(-1)]
public class InitializePlayer : MonoBehaviour
{
    public Vector3 StartingPosition = default;
    public bool IsFinishScene = false;

    private GameObject _player = default;
    private GameObject _deadSplash = default;
    private Sprite _deadSplashSprite = default;
    private Vector3 _deadSplashScale = default;
    public PlayerStats Stats = default;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        if (_player != null && !IsFinishScene)
        {
            _player.transform.position = StartingPosition;
            GameObject.FindGameObjectWithTag("UI_HpBar").transform.GetChild(0).GetComponent<UI_HpBarScript>().Entity = _player;
        }
        else if (_player != null && IsFinishScene)
        {
            _deadSplash = GameObject.FindGameObjectWithTag("DeadSplash");
            Stats = Stats == null ? _player.GetComponent<PlayerStats>() : Stats;
            _deadSplashSprite = _player.GetComponent<SpriteRenderer>().sprite;
            _player.GetComponent<SpriteRenderer>().enabled = false;
            _deadSplashScale = _player.transform.localScale;

            if (_deadSplash != null)
            {
                _deadSplash.GetComponent<SpriteRenderer>().sprite = _deadSplashSprite;
                _deadSplash.transform.localScale = _deadSplashScale * 454;
            }

            Destroy(_player);
        }
    }

    private void Update()
    {
        if (IsFinishScene && _player != null)
        {
            Destroy(_player);
        }
    }
}
