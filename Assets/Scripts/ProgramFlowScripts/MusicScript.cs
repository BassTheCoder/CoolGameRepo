using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public bool IsShrine = false;
    public bool IsBossAlive = false;
    private bool _isLevelFinished = false;
    private GameObject _musicBox;
    void Start()
    {
        _musicBox = GameObject.FindGameObjectWithTag("MusicBox");
        _musicBox.transform.GetChild(0).GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        if (!IsShrine)
        {
            CheckIfLevelIsFinished();

            if (_isLevelFinished && !_musicBox.transform.GetChild(2).GetComponent<AudioSource>().isPlaying)
            {
                _musicBox.transform.GetChild(0).GetComponent<AudioSource>().Stop();
                _musicBox.transform.GetChild(1).GetComponent<AudioSource>().Stop();
                _musicBox.transform.GetChild(2).GetComponent<AudioSource>().Play();
            }
            else if (IsBossAlive && _musicBox.transform.GetChild(0).GetComponent<AudioSource>().isPlaying)
            {
                _musicBox.transform.GetChild(0).GetComponent<AudioSource>().Stop();
                _musicBox.transform.GetChild(1).GetComponent<AudioSource>().Play();
            }
            else if (!IsBossAlive && _musicBox.transform.GetChild(1).GetComponent<AudioSource>().isPlaying)
            {
                _musicBox.transform.GetChild(1).GetComponent<AudioSource>().Stop();
                _musicBox.transform.GetChild(0).GetComponent<AudioSource>().Play();
            }
        }
    }

    private void CheckIfLevelIsFinished()
    {
        if (GetComponent<WinCondition>() != null)
        {
            _isLevelFinished = GetComponent<WinCondition>().IsLevelFinished;
        }
    }
}
