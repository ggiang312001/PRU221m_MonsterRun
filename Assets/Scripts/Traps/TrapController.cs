using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrapController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InteractWithPlayer();
            ReduceHealth();
        }

        if (collision.gameObject.CompareTag("Shield"))
        {
            AudioManager.Play(AudioClipName.Collider);
            ShieldActive.Instance.ShieldCount -= 1;
            gameObject.SetActive(false);
        }
    }

    protected abstract void InteractWithPlayer();

    void ReduceHealth()
    {
        HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        hud.ReduceHealth();
    }
}
