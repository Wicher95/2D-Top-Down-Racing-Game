using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private CarController player;
    private Vector3 playerPos;

    private void Start()
    {
        player = CarController.instance;
    }

    void Update()
    {
        playerPos = player.transform.position;
        playerPos.z = -10;
        transform.position = playerPos;
    }
}
