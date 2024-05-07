using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject portalArc;
    public LevelProgress levelProgress;
    public AudioClip portalActivated;

    private void Start()
    {
        portalArc.SetActive(false);
    }

    void Update()
    {
        if (levelProgress.percentageKilled >= 33)
        {
            if (portalActivated != null)
            {
                GameManager.Instance.audioManager.PlaySound(portalActivated);
            }
            portalArc.SetActive(true);
        }
    }
}
