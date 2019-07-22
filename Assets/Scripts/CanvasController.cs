using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public static int RaceId = 0;

    public GameObject playerCar;
    public GameObject raceCanvas;
    public GameObject menuCanvas;
    public GameObject tracksButtonsHolder;
    public GameObject raceTrackPrefab;

    public RaceTracksHolder raceTracksHolder;

    private void Awake()
    {
        raceCanvas.SetActive(false);        
        playerCar.SetActive(false);

        menuCanvas.SetActive(true);

        for (int i = tracksButtonsHolder.transform.childCount; i > 0; i--)
        {
            Destroy(tracksButtonsHolder.transform.GetChild(i - 1).gameObject);
        }
        for (int i = 0; i < raceTracksHolder.raceTracks.Length; i++)
        {
            int id = i;
            GameObject raceTrack = Instantiate(raceTrackPrefab, tracksButtonsHolder.transform);
            raceTrack.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Track " + (id + 1);
            raceTrack.name = id.ToString();
            raceTrack.GetComponent<Button>().onClick.AddListener(() => LoadTrack(id));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) QuitToMenu();
    }

    private void LoadTrack(int id)
    {
        RaceId = id;
        playerCar.SetActive(true);
        playerCar.transform.position = raceTracksHolder.raceTracks[id].transform.GetChild(0).transform.position;
        playerCar.transform.rotation = raceTracksHolder.raceTracks[id].transform.GetChild(0).transform.rotation;
        raceTracksHolder.raceTracks[id].SetActive(true);
        menuCanvas.SetActive(false);
        raceCanvas.SetActive(true);
        OpenWorldController.instance.ChangeRaceUIvisibility(true);
    }

    public void LoadOpenWorld()
    {
        playerCar.SetActive(true);
        playerCar.transform.position = OpenWorldController.instance.world.transform.GetChild(0).transform.position;
        playerCar.transform.rotation = OpenWorldController.instance.world.transform.GetChild(0).transform.rotation;
        menuCanvas.SetActive(false);
        raceCanvas.SetActive(true);
        OpenWorldController.instance.world.SetActive(true);
        OpenWorldController.instance.ChangeRaceUIvisibility(false);
    }

    private void QuitToMenu()
    {
        RaceController.instance?.ResetRace();
        OpenWorldController.instance.world.SetActive(false);
        raceCanvas.SetActive(false);
        playerCar.SetActive(false);
        for (int i = 0; i < raceTracksHolder.raceTracks.Length; i++)
        {
            raceTracksHolder.raceTracks[i].SetActive(false);
        }
        menuCanvas.SetActive(true);
    }

    public void ExitGame()
    {
#if UNITY_EDTIOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
