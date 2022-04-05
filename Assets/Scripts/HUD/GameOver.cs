using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [Header("UI")]
    public GameObject gameOverMenu;
    public bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOverMenu.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
        if(isGameOver)
        {
            gameOverMenu.SetActive(true);
            Time.timeScale = 0f;
        } else {
            gameOverMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("PauseMenu");
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
