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

    private void Start()
    {
        musicSource.clip = BackGround;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXClip.PlayOneShot(clip);
    }
}
