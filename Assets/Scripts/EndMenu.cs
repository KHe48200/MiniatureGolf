using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndMenu : MonoBehaviour
{
    public TextMeshProUGUI totalScoreUGUI;

    private void Update()
    {
        //Etsitään GameObjekti missä TotalScore scripti
        GameObject tso = GameObject.FindGameObjectWithTag("TotalScore");
        TotalScore totalScore = tso.GetComponent<TotalScore>();

        totalScoreUGUI.text = totalScore.totalScore.ToString();
    }

    public void MainMenu()
    {
        GameObject tso = GameObject.FindGameObjectWithTag("TotalScore");
        Destroy(tso);
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


}
