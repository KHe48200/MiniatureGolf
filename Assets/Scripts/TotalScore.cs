using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalScore : MonoBehaviour
{
    public int totalScore;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
