using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioSource _playerFailure;
    public AudioSource _BGmusic;
    public AudioSource _playerSuccess;
    public AudioSource _gameOver;
    public AudioClip _one;
    public AudioClip _two;
    public AudioClip _three;

    private void Awake()
    {
        
    }

    // SOUNDS TO PLUG
    // package sucess
    // package failure
    // package spawned
    // package sucked
    // package fell on belt
    // player walk
    // player promoted
    // player demoted
    // belt sound
    // 


    public void PlayFailure ()
    {
        _playerFailure.Play();
    }

    public void PlaySuccess()
    {
        _playerSuccess.Play();
    }
    public void GameLost()
    {
        _gameOver.Play();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.J))
        {
            _BGmusic.Stop();
            _BGmusic.clip = _one;
            _BGmusic.Play();
        }

        if (Input.GetKeyUp(KeyCode.K))
        {
            _BGmusic.Stop();
            _BGmusic.clip = _two;
            _BGmusic.Play();
        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            _BGmusic.Stop();
            _BGmusic.clip = _three;
            _BGmusic.Play();
        }
    }
}
