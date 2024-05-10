using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject portalArc;
    public LevelProgress levelProgress;
    public AudioClip portalActivated;
    private bool audioPlayed;

    private void Start()
    {
        audioPlayed = false;
        portalArc.SetActive(false);
    }

    void Update()
    {
        if (levelProgress.percentageKilled >= 33)
        {
            if (portalActivated != null && !audioPlayed)
            {
                GameManager.Instance.audioManager.PlaySound(portalActivated);
                audioPlayed = true;
            }
            portalArc.SetActive(true);
        }
    }
}
