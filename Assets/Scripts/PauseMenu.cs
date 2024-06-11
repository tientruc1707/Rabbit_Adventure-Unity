using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;  // Unpause the game
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Restart current level
    }

    public void Home()
    {
        SceneManager.LoadScene("Main Menu");  // Load main menu
    }

    public void BackToPauseMenu()
    {
        pauseMenuUI.SetActive(true);
    }
}

