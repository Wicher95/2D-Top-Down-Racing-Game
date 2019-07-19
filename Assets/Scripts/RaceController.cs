using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RaceController : MonoBehaviour
{
    public static RaceController instance;

    public TextMeshProUGUI timer;
    public TextMeshProUGUI bestTime;
    public TextMeshProUGUI wrongDirection;
    private float raceTime;
    public bool raceStarted { get; private set; }
    private float bestRaceTime;

    public float BestRaceTime
    {
        get => bestRaceTime;
        set
        {
            bestRaceTime = value;
            PlayerPrefs.SetFloat("BestRace", value);
        }
    }

    private void Awake()
    {
        instance = this;
        raceStarted = false;
        BestRaceTime = PlayerPrefs.GetFloat("BestRace", 0);
        SetBestRaceText();
    }

    private void Update()
    {
        if (raceStarted)
        {
            raceTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(raceTime / 60F);
            int seconds = Mathf.FloorToInt(raceTime - minutes * 60);
            float miliseconds = (raceTime - minutes * 60 - seconds) * 1000;
            timer.text = string.Format("{0:0}:{1:00}:{2:000}", minutes, seconds, miliseconds);
        }
    }

    public void StartRace()
    {
        if ((raceTime < BestRaceTime || BestRaceTime == 0 ) && raceTime > 0.1f)
        {
            BestRaceTime = raceTime;
            SetBestRaceText();
        }
        raceStarted = true;
        raceTime = 0;
        wrongDirection.enabled = false;
    }

    private void SetBestRaceText()
    {
        int minutes = Mathf.FloorToInt(BestRaceTime / 60F);
        int seconds = Mathf.FloorToInt(BestRaceTime - minutes * 60);
        float miliseconds = (BestRaceTime - minutes * 60 - seconds) * 1000;
        bestTime.text = "Best - " + string.Format("{0:0}:{1:00}:{2:000}", minutes, seconds, miliseconds);
    }    
}
