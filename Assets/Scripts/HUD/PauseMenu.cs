using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("UI")]
    public GameObject pauseMenu;
    public GameObject continueButton;
    public GameObject mainMenuButton;
    public static bool isPaused;//IF YOU NEED TO PAUSE ACTIONS IN OTHER SCRIPTS, REFER TO THIS VARIABLE
    private InputAction PauseAction = new InputAction(binding: "<Keyboard>/escape");
    [Header("Input Settings")]
    [SerializeField]
    private PlayerInput playerInput;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void Update()
    {
        PauseAction.Enable();
        if(PauseAction.triggered)
        {
            if(isPaused)
            {
                ResumeGame();
            } else {
                PauseGame();
            }
        } 
        
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
