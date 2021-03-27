using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialContinueButton : MonoBehaviour
{
    public GameObject TutorialUI;
    public GameObject ScoreUI;
    public GameObject Golfball;
    public Golfball ball;

    private void Start()
    {
        Time.timeScale = 0f;
        Golfball.SetActive(false);
        ball.score = 7;
    }

    public void TutorialContinue()
    {
        Time.timeScale = 1f;
        TutorialUI.SetActive(false);
        ScoreUI.SetActive(true);
        Golfball.SetActive(true);
    }
}
