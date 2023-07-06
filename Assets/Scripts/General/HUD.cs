using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    TextMeshProUGUI healthText;
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
        
    }
    public void ReduceHealth()
    {
        health -= 1;
        healthText.text = bouncePrefix + health.ToString();
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

    public int GetHealth()
    {
       return health;   
    }
}
