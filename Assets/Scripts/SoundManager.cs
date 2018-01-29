using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioSource _playerFailure;
    public AudioSource music;
    public AudioSource _playerSuccess;
    public AudioClip _gameOver;

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
        music.clip = _gameOver;
    }

    private void Update()
    {

    }
}
