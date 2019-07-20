using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is repsonsible to remove the efect that trail on enable is rendered from position when it was last disabled
public class TrailController : MonoBehaviour
{
    private float defaultTime;
    private TrailRenderer trail;

    private void Awake()
    {
        trail = GetComponent<TrailRenderer>();
        defaultTime = trail.time;
    }

    private void OnEnable()
    {
        Invoke("EnableTrail", 0.1f);
    }

    private void OnDisable()
    {
        trail.time = -1;
    }

    private void EnableTrail()
    {
        trail.time = defaultTime;
    }
}
