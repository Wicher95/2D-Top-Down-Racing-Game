using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWorldController : MonoBehaviour
{
    public static OpenWorldController instance;
    public GameObject world;
    public GameObject raceTimer;
    public GameObject bestRaceTime;

    private void Awake()
    {
        instance = this;
    }

    public void ChangeRaceUIvisibility(bool visibility)
    {
        raceTimer.SetActive(visibility);
        bestRaceTime.SetActive(visibility);
    }
}
