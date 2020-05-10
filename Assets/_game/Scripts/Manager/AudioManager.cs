//Made by SquidBait
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
    public AudioSource MusicSource;
    public AudioSource [] FXSourcesMix;

    public AudioClip shoot;
    public AudioClip hit;
    public AudioClip explosion;

    public void PlaySoundFX(AudioClip _clip, int _channel)
    {
        FXSourcesMix[_channel].clip = _clip;
        FXSourcesMix[_channel].Play();
    }
}
