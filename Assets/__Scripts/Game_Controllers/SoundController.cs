using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour
{
    // == private fields ==
    private AudioSource audioSource;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource tumbleweed;
    private float volume = 0.3f;

    void Update()
    {
        backgroundMusic.volume = volume;
        audioSource.volume = volume;
        if (tumbleweed)
        {
            tumbleweed.volume = volume;
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // == public methods ==
    public void PlayOneShot(AudioClip clip)
    {
        if(clip)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public void PlayOneShot(AudioClip clip, float volume)
    {
        if (clip)
        {
            audioSource.PlayOneShot(clip, volume);
        }
    }

    // need a method to return this object - to give other classes
    // access to this one
    public static SoundController FindSoundController()
    {
        var sc = FindObjectOfType<SoundController>();
        if(!sc)
        {
            Debug.Log("There was no sound controller found!");
        }
        return sc;
    }

    public void SetVolume(float vol)
    {
        volume = vol;
    }
}
