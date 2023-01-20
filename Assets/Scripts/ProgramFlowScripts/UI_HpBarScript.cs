using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_HpBarScript : MonoBehaviour
{
    private GameObject Player = null;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Player != null)
        {
            var currentHpPercent = Player.GetPlayersCurrentHpPercent();
            transform.GetChild(2).gameObject.transform.localScale = new Vector3(currentHpPercent, 1, 1);
        }
    }
}
