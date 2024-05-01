using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public int damageStrength;
    private Animator animator;
    private bool canAttack = true; // Variable de estado para controlar si se puede realizar un ataque

    private void Start()
    {
        hitPoints.currentValue = hitPoints.maxValue;
        animator = GetComponent<Animator>(); // Obtener el Animator del jugador
    }

    private void Update()
    {
        // Si se puede atacar y se presiona el botón izquierdo del ratón
        if (canAttack && Input.GetMouseButtonDown(0))
        {
            // Activar el trigger isAttacking del Animator
            animator.SetTrigger("Attack");
            // Iniciar la corrutina para controlar la duración del ataque
            StartCoroutine(AttackCooldown());
        }
    }

    // Corrutina para controlar el tiempo de duración del ataque
    IEnumerator AttackCooldown()
    {
        // Indicar que no se puede atacar durante la animación de ataque
        canAttack = false;
        // Esperar a que termine la animación de ataque
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        Debug.Log("Ataque");
        // Indicar que se puede atacar nuevamente
        canAttack = true;
    }
}