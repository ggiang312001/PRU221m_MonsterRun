using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueGame : MonoBehaviour
{
   
    public static bool isContinue = false;
    public static bool isStart = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Continue()
    {
        LoadGameSave.isLoadFinish = false;
        isContinue = true;
        SceneManager.LoadScene("SampleScene");
    }
    public void StartGame()
    {

        isStart = true;
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }


}
