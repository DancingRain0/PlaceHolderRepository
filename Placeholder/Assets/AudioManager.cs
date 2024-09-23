using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-----------Audio Source----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXClip;

    [Header("-----------Audio Clip----------")]
    public AudioClip BackGround;
    public AudioClip Shoot;
    public AudioClip Pickup;
    public AudioClip MainMenu;

    public void Start()
    {
        musicSource.clip = BackGround;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXClip.PlayOneShot(clip);
    }

    public void StopMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }
    public void PlayMusic(AudioClip clip)
    {
        if (clip != null)
        {
            musicSource.clip = clip;
            musicSource.Play();
        }
    }
}
