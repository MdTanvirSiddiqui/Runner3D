using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject mainMenuPanel;
    public GameObject congratulationPanel;
    public GameObject gameOverPanel;
    public GameObject progressBar;
    public Movement movement;
    public void StartGame()
    {
        instance = this;
        mainMenuPanel.SetActive(false);
        progressBar.SetActive(true);
        movement.startGame = true;
    }
    public void Restart()
    {
        gameOverPanel.SetActive(false);
        progressBar.SetActive(false);
        congratulationPanel.SetActive(false);
    }

    public void Congratulation()
    {
        congratulationPanel.SetActive(true);
        progressBar.SetActive(false);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        progressBar.SetActive(false);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
