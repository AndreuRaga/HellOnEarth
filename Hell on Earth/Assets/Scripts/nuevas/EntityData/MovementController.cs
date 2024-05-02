using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    Vector2 movement = new Vector2();
    Rigidbody2D _rb2d;
    Animator _anim;
    SpriteRenderer _spriteRend;
    // Variable para almacenar la última dirección válida
    Vector2 lastDirection = Vector2.zero;

    // Variable para controlar si el jugador puede moverse
    private bool canMove = true;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _spriteRend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Si el jugador puede moverse, actualizar su movimiento
        if (canMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            movement = Vector2.ClampMagnitude(movement, 1.0f);
            _rb2d.velocity = movement * movementSpeed;
            UpdateState();
        }
    }

    private void UpdateState()
    {
        bool stopped = Mathf.Approximately(movement.x, 0) && Mathf.Approximately(movement.y, 0);
        if (!stopped)
        {
            // Si hay movimiento, actualiza la última dirección válida
            lastDirection = movement;
        }
        _anim.SetBool("isWalking", !stopped);
        _anim.SetFloat("xDir", lastDirection.x);
        _anim.SetFloat("yDir", lastDirection.y);
        //_spriteRend.flipX = (movement.x < 0);
    }

    // Método para detener temporalmente el movimiento del jugador
    public void StopMovementTemporarily(float duration)
    {
        // Desactivar el movimiento del jugador
        canMove = false;
        // Iniciar una corutina para reactivar el movimiento después de la duración especificada
        StartCoroutine(ReactivateMovement(duration));
    }

    // Corrutina para reactivar el movimiento después de un tiempo
    IEnumerator ReactivateMovement(float duration)
    {
        yield return new WaitForSeconds(duration);
        // Reactivar el movimiento del jugador
        canMove = true;
    }
}
