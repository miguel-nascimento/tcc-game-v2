using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    void Start()
    {
        gameOverUI.SetActive(false);
    }
    public void GameOverEvent()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0.01f;
    }

    public void Play()
    {
        SceneManager.LoadScene("PrimeiraFase");
    }
    
    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }
}
    