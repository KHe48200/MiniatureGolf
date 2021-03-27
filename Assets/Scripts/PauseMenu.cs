using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject scoreUI;
    public GameObject Golfball;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(isPaused)
            {
                ResumeGame();
            } else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        scoreUI.SetActive(true);
        Golfball.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        scoreUI.SetActive(false);
        //Estetään ettei Resume nappulan painaminen lähetä palloa liikkeelle
        Golfball.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void QuitGame()
    {
        /*Debug.Log("Quit");
        Application.Quit();*/
        ResumeGame();
        SceneManager.LoadScene(0);
    }
}
