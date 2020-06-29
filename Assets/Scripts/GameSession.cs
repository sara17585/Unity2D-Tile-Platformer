using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLife = 3;
    [SerializeField] int score = 0;

    [SerializeField] TextMeshProUGUI lives;
    [SerializeField] TextMeshProUGUI scoreText;


    private void Awake()
    {
        int numberGameSession = FindObjectsOfType<GameSession>().Length;
        if(numberGameSession>1)
        {
            Destroy(gameObject);

        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        lives.text = playerLife.ToString();
        scoreText.text = score.ToString();

    }

    public void AddToScore(int pointsToAdd)

    {
        score += pointsToAdd;
        scoreText.text = score.ToString();

    }

   public void ProcessPlayerDeath()
    {
        if(playerLife>1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    private void TakeLife()
    {
        playerLife--;
        lives.text = playerLife.ToString();
        var currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
