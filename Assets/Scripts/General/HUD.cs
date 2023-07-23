using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Text txtTinme;
    [SerializeField] private Button btnHome;
    // Start is called before the first frame update
    [SerializeField]
    TextMeshProUGUI healthText;
    [SerializeField]
    TextMeshProUGUI timeText;
    private float timer = 0.0f;
    public static bool isStart = false;

    int health;
    const string bouncePrefix = "X ";
    private void OnEnable()
    {
        btnHome.onClick.AddListener(Replay);
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

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
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
        if (health >= 1)
        {
            health -= 1;
            healthText.text = bouncePrefix + health.ToString();
        }
        if (health == 0)
        {
            GameOver();
            healthText.text = bouncePrefix + health.ToString();
        }

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
