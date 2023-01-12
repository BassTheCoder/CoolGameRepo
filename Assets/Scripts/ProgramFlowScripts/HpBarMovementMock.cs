using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarMovementMock : MonoBehaviour
{
    public Sprite[] HpBarForegrounds = new Sprite[0];
    private List<Sprite> _hpSprites = new List<Sprite>();

    private bool increasing = false;

    private void Start()
    {
        foreach (var item in HpBarForegrounds)
        {
            _hpSprites.Add(item);
        }
    }

    void FixedUpdate()
    {
        CheckForBarSwap();
        CheckDirection();
        if (increasing)
        {
            gameObject.transform.localScale += new Vector3(0.01f, 0, 0);
        }
        else
        {
            gameObject.transform.localScale -= new Vector3(0.01f, 0, 0);
        }
    }

    private void CheckForBarSwap()
    {
        if (gameObject.transform.localScale.x <= 0)
        {
            var currentSprite = transform.parent.GetChild(0).GetComponent<SpriteRenderer>().sprite;
            if (_hpSprites.IndexOf(currentSprite) == _hpSprites.Count-1)
            {
                transform.parent.GetChild(0).GetComponent<SpriteRenderer>().sprite = _hpSprites[0];
            }
            else
            {
                transform.parent.GetChild(0).GetComponent<SpriteRenderer>().sprite = _hpSprites[_hpSprites.IndexOf(currentSprite) + 1];
            }
        }
    }

    private void CheckDirection()
    {
        if (gameObject.transform.localScale.x <= 0)
        {
            increasing = true;
        }
        else if (gameObject.transform.localScale.x >= 1)
        {
            increasing = false;
        }
    }
}
