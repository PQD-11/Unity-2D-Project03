using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFeedback : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource targetAudioSource;
    [Range(0, 1)]
    public float volume = 1;

    public void PlayClip()
    {
        if (audioClip == null) { return; }
        targetAudioSource.volume = this.volume;
        targetAudioSource.PlayOneShot(audioClip);
    }

    public void PlaySpecificClip(AudioClip clipToPlay = null)
    {
        if (clipToPlay == null)
        {
            clipToPlay = audioClip;
        }
        if (clipToPlay == null) { return; }
        targetAudioSource.volume = this.volume;
        targetAudioSource.PlayOneShot(clipToPlay);
    }
}
