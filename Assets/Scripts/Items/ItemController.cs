using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemController : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            InteractWithPlayer();
            GameObject audio = GameObject.FindGameObjectWithTag("audio");
            Audio audio_manager = audio.GetComponent<Audio>();
            audio_manager.PlayCollectItem();
        }
    }

    protected abstract void InteractWithPlayer();
}
