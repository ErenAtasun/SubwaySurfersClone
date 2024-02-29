using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectCoin : MonoBehaviour
{

    int score;
    int highScore;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
        highScore = PlayerPrefs.GetInt("highscore");
        highScoreText.text = highScore.ToString(); 
        

    }
    void FixedUpdate()
    {
        UpdateScore();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            Destroy(other.gameObject);
        }
    }
    public void AddCoin()
    {
        score += 10;
        scoreText.text = score.ToString();
    }
    public void UpdateScore()
    {
        score ++;
        scoreText.text = score.ToString();
        if (score> highScore)
        {
            highScore = score;
            highScoreText.text = highScore.ToString();
            PlayerPrefs.SetInt("highscore", highScore);
        }
    }
}
