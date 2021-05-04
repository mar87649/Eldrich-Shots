using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameOver;
    public Button restartButton;
    public int score;
    public int health;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI gameWonText;
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        gameWonText.gameObject.SetActive(false);
        gameOver = false;
        restartButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        score = GameObject.Find("Box").GetComponent<Counter>().Count;
        health = GameObject.Find("Player").GetComponent<PlayerController>().health;

        if (score>9)
        {
            gameOver = true;
            GameWon();
        }
        if (health<1)
        {
            gameOver = true;
            GameLost();
        }
        if (gameOver)
        {
            
        }
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void GameWon(){
        gameWonText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    private void GameLost(){
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
}
