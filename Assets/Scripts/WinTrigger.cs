using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class WinTrigger : MonoBehaviour
{
    public Golfball golfball;
    public GameObject winScreen;
    public GameObject scoreScreen;
    public TextMeshProUGUI endScoreUGUI;
    public TextMeshProUGUI totalScoreUGUI;
    private AudioSource holeSound;

    // Start is called before the first frame update
    void Start()
    {
        holeSound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (golfball.score == 0)
        {
            EndLevel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        EndLevel();
    }

    private void EndLevel()
    {
        holeSound.Play();
        Time.timeScale = 0f;
        winScreen.SetActive(true);
        scoreScreen.SetActive(false);
        //Etsitään GameObjekti missä TotalScore scripti
        GameObject tso = GameObject.FindGameObjectWithTag("TotalScore");
        TotalScore totalScore = tso.GetComponent<TotalScore>();
        //Lisätään tason pisteet kokonais pisteisiin
        totalScore.totalScore = totalScore.totalScore + golfball.score;
        //Näytetään molemmat pisteet tekstikentissä
        endScoreUGUI.text = golfball.score.ToString();
        totalScoreUGUI.text = totalScore.totalScore.ToString();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
