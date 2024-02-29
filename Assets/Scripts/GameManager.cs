using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject DeahtScreen;
    

    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Start()
    {
        gameOver = false;
    }

    public void GameOver()
    {
        gameOver = true;
        DeahtScreen.SetActive(true);
        
        

    }

    void Update()
    {
        
    }
}
