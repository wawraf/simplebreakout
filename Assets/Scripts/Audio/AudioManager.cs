using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{
    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioName, AudioClip> audioClips = new Dictionary<AudioName, AudioClip>();

    public static bool Initialized
    {
        get { return initialized; }
    }

    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;

        audioClips.Add(AudioName.Click, Resources.Load<AudioClip>("Click"));
        audioClips.Add(AudioName.Freeze, Resources.Load<AudioClip>("Freeze"));
        audioClips.Add(AudioName.SpeedUp, Resources.Load<AudioClip>("SpeedUp"));
        audioClips.Add(AudioName.Unfreeze, Resources.Load<AudioClip>("Unfreeze"));
        audioClips.Add(AudioName.SpeedDown, Resources.Load<AudioClip>("SpeedDown"));
        audioClips.Add(AudioName.BallLost, Resources.Load<AudioClip>("BallLost"));
        audioClips.Add(AudioName.GameOver, Resources.Load<AudioClip>("GameOver"));
    }

    public static void Play(AudioName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
}
