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
        RestartGame();
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
        Time.timeScale = 0f;


    }
    public void RestartGame()
    {
       
        Time.timeScale = 1f; 
        gameOver = false; 
    }

    void Update()
    {
        
    }
}
