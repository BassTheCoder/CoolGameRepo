using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public Transform ShootPoint = default;
    public GameObject Shot = null;
    private GameObject _player = null;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }


    private void Update()
    {
        if (_player == null)
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }
        var ammo = _player.GetComponent<Stats>().Ammo;
        if (ammo > 0 && Input.GetKeyDown(Keybinds.AttackRanged))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, ShootPoint.position.z));
        var angle = AngleBetweenTwoPoints(ShootPoint.position, mousePosition);
        Instantiate(Shot, ShootPoint.position, Quaternion.Euler(0f, 0f, angle+180));
        _player.GetComponent<Stats>().Ammo--;
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
