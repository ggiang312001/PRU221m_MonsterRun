using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The audio manager
/// </summary>
public static class AudioManager
{
    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    /// <summary>
    /// Gets whether or not the audio manager has been initialized
    /// </summary>
    public static bool Initialized
    {
        get { return initialized; }
    }

    /// <summary>
    /// Initializes the audio manager
    /// </summary>
    /// <param name="source">audio source</param>
    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;
        audioClips.Add(AudioClipName.FireDamage, 
            Resources.Load<AudioClip>("Audio/fire1"));
        audioClips.Add(AudioClipName.Jump,
            Resources.Load<AudioClip>("Audio/jump"));
        audioClips.Add(AudioClipName.ItemCollect,
            Resources.Load<AudioClip>("Audio/item"));
        audioClips.Add(AudioClipName.Bum,
             Resources.Load<AudioClip>("Audio/bum"));
        audioClips.Add(AudioClipName.Collider,
             Resources.Load<AudioClip>("Audio/vacham"));
        audioClips.Add(AudioClipName.Button,
              Resources.Load<AudioClip>("Audio/button"));
        //audioClips.Add(AudioClipName.TeddyShot,
        //    Resources.Load<AudioClip>("TeddyShot"));
    }

    /// <summary>
    /// Plays the audio clip with the given name
    /// </summary>
    /// <param name="name">name of the audio clip to play</param>
    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }


}
