using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IsometricPlayerMovementController : MonoBehaviour
{


    public float movementSpeed = 1f;
    IsometricCharacterRenderer isoRenderer;
    public TMP_Text TextComponent;
    public GameObject ThoughtsGameObj;
    Rigidbody2D rb;

    private Color originalColor;
    private Vector2 lastDirection = Vector2.right; // Default direction
    public float dashSpeed = 30f;
    public float dashDuration = 0.7f; // Duration of the dash in seconds
    private bool isDashing = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
        originalColor = isoRenderer.GetComponent<SpriteRenderer>().color;
    }

    public void think(string bubble)
    {
        ThoughtsGameObj.SetActive(true);
        TextComponent.text = bubble;
        StartCoroutine(stopThoughts());
    }

    void Update()
    {

        // Movement based on horizontal and vertical axes
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized * movementSpeed;
        rb.velocity = movement;

        isoRenderer.SetDirection(movement);

        // Check if moving and update last direction
        if (movement.magnitude > 0)
        {
            lastDirection = movement.normalized;
        }

        // Dash when spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Dash(lastDirection));
        }
    }

    IEnumerator Dash(Vector2 direction)
    {
        // Disable movement during dash
        rb.velocity = Vector2.zero;

        // Apply dash velocity
        rb.velocity = direction * dashSpeed;

        // Wait for dash duration
        yield return new WaitForSeconds(dashDuration);

        // Reset velocity after dash duration
        rb.velocity = Vector2.zero;
    }

    IEnumerator stopThoughts()
    {
        yield return new WaitForSeconds(4);
        TextComponent.text = "";
        ThoughtsGameObj.SetActive(true);
    }


    /*
            Vector2 currentPos = rbody.position;
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
            inputVector = Vector2.ClampMagnitude(inputVector, 1);

            if (Input.GetButton("Fire1"))
            {
                var mousePos = Input.mousePosition;
                mousePos.x -= Screen.width / 2; mousePos.y -= Screen.height / 2;

                inputVector = new Vector2(mousePos.x, mousePos.y);
                inputVector = Vector2.ClampMagnitude(inputVector, 1);
            }
            if (horizontalInput != 0f || verticalInput != 0f)
                lastDirection = inputVector;

            float movSpd = movementSpeed;

        Debug.Log(lastDirection.ToString());

            if (Input.GetButton("Jump") && !isDashing)
            {
                StartCoroutine(Dash());
    }
    Vector2 movement = inputVector * movSpd;
    Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;

    isoRenderer.SetDirection(movement);
    rbody.MovePosition(newPos);


    // Regular movement
    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");
    Vector2 movement = new Vector2(moveHorizontal, moveVertical);
    isoRenderer.SetDirection(movement);
    rbody.MovePosition(rbody.position + movement * movementSpeed * Time.deltaTime);
    */
}
