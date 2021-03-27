using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        GameObject tso = GameObject.FindGameObjectWithTag("TotalScore");
        TotalScore totalScore = tso.GetComponent<TotalScore>();
        //totalScore.totalScore = 0;
    }

    public void PlayGame ()
    {
        //Ladataan seuraava scene build indexin avulla
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
