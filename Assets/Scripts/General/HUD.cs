using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject gameOver;
    [SerializeField] private Text txtTinme;
    [SerializeField] private Button btnReplay;
    [SerializeField] private PlayerController player;
    [SerializeField]
    TextMeshProUGUI healthText;
    [SerializeField]
    TextMeshProUGUI timeText;
    private float timer = 0.0f;

    private PlayerState currentState;


    int health;
    const string bouncePrefix = "X ";
    private void OnEnable()
    {
        btnReplay.onClick.AddListener(Replay);
    }
    void Start()
    {
        health = 5;
        healthText.text = bouncePrefix + health.ToString();
    }

    public void Replay() 
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        timer+= Time.deltaTime;
        DisplayTime();
    }

    public void GameOver()
    {
        txtTinme.text = timeText.text;
        gameOver.SetActive(true);
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
        else GameOver();
    }

    public void Dead()
    {
        health = 0;
        GameOver();
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
