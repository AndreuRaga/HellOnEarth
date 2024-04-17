using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactPlayer : MonoBehaviour
{
    public KeyCode interactionKey = KeyCode.Return; // Key for interaction

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if collided with the GameObject tagged as "Interactable"
        if (collision.gameObject.CompareTag("Interactable"))
        {
            collision.gameObject.transform.parent.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        // Check if collided with the GameObject tagged as "Interactable"
        if (collision.gameObject.CompareTag("Interactable"))
        {
            collision.gameObject.transform.parent.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    void Update()
    {
        // Check for interaction input
        if (Input.GetKeyDown(interactionKey))
        {
            // Perform interaction logic if already colliding with an interactable object
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Interactable"))
                {
                    InteractWithObject(collider.gameObject);
                    break;
                }
            }
        }
    }

    void InteractWithObject(GameObject interactableObject)
    {
        interactableObject.transform.parent.gameObject.GetComponent<DatosEntidad>().inter();
    }
}
