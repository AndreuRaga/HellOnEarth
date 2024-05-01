using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private bool playerInRange = false;

    void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the player enters the trigger zone
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        // Check if the player exits the trigger zone
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    void Update()
    {
        // Check if the player is in range and the left mouse button is pressed
        if (playerInRange && Input.GetMouseButtonDown(0))
        {
            //Viajar al siguiente nivel
            GameManager.Instance.GoToNextLevel(0f);
        }
    }
}
