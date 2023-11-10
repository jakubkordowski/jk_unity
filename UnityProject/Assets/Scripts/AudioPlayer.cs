using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip dice;
    public AudioClip win;
    public float volume = 0.5f;

    public void PlayAudio(AudioClip clip)
    {
        audioSource.PlayOneShot(clip, volume);
    }

    public void PlayWinAudio()
    {
        PlayAudio(win);
    }

    public void PlayDiceAudio()
    {
        PlayAudio(dice);
    }
}
