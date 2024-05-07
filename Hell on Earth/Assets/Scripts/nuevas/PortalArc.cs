using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalArc : MonoBehaviour
{
    public GameObject portalEntrance;
    private bool playerInRange = false;
    public AudioClip portalTeleport;
    void Start()
    {
        portalEntrance.SetActive(false);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player enters the trigger zone
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            portalEntrance.SetActive(true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the player exits the trigger zone
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            portalEntrance.SetActive(false);
        }
    }
    private void Update()
    {
        if (playerInRange && Input.GetMouseButtonDown(0))
        {
            if (portalTeleport != null)
            {
                GameManager.Instance.audioManager.PlaySound(portalTeleport);
            }
            //Viajar al siguiente nivel
            GameManager.Instance.GoToNextLevel(0f);
        }
    }
}
