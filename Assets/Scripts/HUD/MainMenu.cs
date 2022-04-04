using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("UI")]
    public GameObject controlsMenu;
    private bool controlsOpen = false;
    public GameObject creditsMenu;
    private bool creditsOpen = false;


    // Start is called before the first frame update
    void Start()
    {
        controlsMenu.SetActive(controlsOpen);
        creditsMenu.SetActive(creditsOpen);
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void Controls()
    {
        controlsOpen = !controlsOpen;
        controlsMenu.SetActive(controlsOpen);
    }

    public void Credits()
    {
        creditsOpen = !creditsOpen;
        creditsMenu.SetActive(creditsOpen);
    }

    public void ResumeGame()
    {
        SceneManager.LoadScene("PauseMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

}
