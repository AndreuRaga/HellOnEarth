using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject portalArc;
    public LevelProgress LevelProgress;

    private void Start()
    {
        portalArc.SetActive(false);
    }

    void Update()
    {
        if (LevelProgress.percentageKilled >= 33)
        {
            portalArc.SetActive(true);
        }
    }
}
