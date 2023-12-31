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
            AudioManager.Play(AudioClipName.ItemCollect);
        }
    }

    protected abstract void InteractWithPlayer();
}
