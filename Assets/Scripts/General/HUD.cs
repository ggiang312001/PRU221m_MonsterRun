using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    TextMeshProUGUI healthText;
    [SerializeField]
    TextMeshProUGUI timeText;
    private float timer = 0.0f;
    
    int health;
    const string bouncePrefix = "X ";
    void Start()
    {
        
        health = 5;
        healthText.text = bouncePrefix + health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timer+= Time.deltaTime;
        DisplayTime();
    }

    public void DisplayTime()
    {
        int minutes = Mathf.FloorToInt(timer / 60.0f);
        int second = Mathf.FloorToInt(timer - minutes * 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, second);
    }
    public void ReduceHealth()
    {
        if (health > 0)
        {
            health -= 1;
            healthText.text = bouncePrefix + health.ToString();
        }
    }

    public void Dead()
    {
        health = 0;
        healthText.text = bouncePrefix + health.ToString();
    }

    public void IncreaseHealth()
    {
        health += 1;
        healthText.text = bouncePrefix + health.ToString();
    }

    public void SetHealth(int health1)
    {
        health = health1;
        healthText.text = bouncePrefix + health.ToString();
    }
    public int GetHealth()
    {
       return health;   
    }

    public float GetTimer()
    {
        return timer;
    }

    public void SetTimer(float time)
    {
        timer = time;
    }
}
