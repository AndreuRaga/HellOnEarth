using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public int damageStrength;
    private Animator animator;

    private MovementController movementController; // Referencia al controlador de movimiento

    private void Start()
    {
        hitPoints.currentValue = hitPoints.maxValue;
        animator = GetComponent<Animator>();

        // Obtener la referencia al controlador de movimiento
        movementController = GetComponent<MovementController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Iniciar la animaci�n de ataque
            animator.SetTrigger("Attack");
            // Detener temporalmente el movimiento del jugador durante la animaci�n de ataque
            movementController.StopMovementTemporarily(GetAttackAnimationDuration());
        }
    }

    // M�todo para obtener la duraci�n de la animaci�n de ataque
    private float GetAttackAnimationDuration()
    {
        // Suponiendo que "Attack" es el nombre del estado de la animaci�n de ataque
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            if (clip.name.Contains("attack", StringComparison.OrdinalIgnoreCase))
            {
                return clip.length;
            }
        }
        return 0f;
    }
}
