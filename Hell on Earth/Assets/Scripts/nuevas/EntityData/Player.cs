using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public int damageStrength;
    private Animator animator;

    private void Start()
    {
        hitPoints.currentValue = hitPoints.maxValue;
        animator = GetComponent<Animator>(); // Obtener el Animator del jugador
    }

    private void Update()
    {
        // Si se puede atacar y se presiona el bot�n izquierdo del rat�n
        if (Input.GetMouseButtonDown(0))
        {
            // Configurar el par�metro isAttacking del Animator a true
            animator.SetBool("isAttacking", true);
        }
        animator.SetBool("isAttacking", false);
    }
}