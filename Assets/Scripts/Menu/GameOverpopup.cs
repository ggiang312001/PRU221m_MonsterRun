using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverpopup : MonoBehaviour
{
    public static GameOverpopup instance;
    private void Awake()
    {
        instance = this;
    }

    public void GameOver() 
    {

    }


}
