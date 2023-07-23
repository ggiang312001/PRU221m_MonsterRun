using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip clip;
    AudioClip clipColl;
    AudioClip clipJump;
    AudioClip clipFire;
    void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();// audio Source
        clip = Resources.Load<AudioClip>("Audio/item");
        clipColl = Resources.Load<AudioClip>("Audio/bum");
        clipJump = Resources.Load<AudioClip>("Audio/jump");
        clipFire= Resources.Load<AudioClip>("Audio/fire1");

    }
    public void PlayFire()
    {
        audioSource.PlayOneShot(clipFire);
    }
    public void PlayCollectItem()
    {
        audioSource.PlayOneShot(clip);
    }
    public void PlayColl()
    {
        audioSource.PlayOneShot(clipColl);
    }

    public void PlayJump()
    {
        audioSource.PlayOneShot(clipJump);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
