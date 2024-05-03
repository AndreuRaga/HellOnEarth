using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public int damageStrength;
    public float attackRange;
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
            //Centro o posici�n de Player
            Vector2 centro = transform.position;
            // Definir el filtro para solo colisionar con GameObjects que tengan la etiqueta "Enemy"
            ContactFilter2D contactFilter = new ContactFilter2D();
            contactFilter.SetLayerMask(LayerMask.GetMask("Enemies"));
            contactFilter.useLayerMask = true;
            //colliders enemigos
            List<Collider2D> enemyCollidersList = new List<Collider2D>();
            Physics2D.OverlapCircle(centro, attackRange, contactFilter, enemyCollidersList);
            if (enemyCollidersList.Count > 0)
            {
                Vector2 firstColliderPosition = enemyCollidersList[0].transform.position;
                float distancia = Vector2.Distance(centro, firstColliderPosition);
                if (distancia <= attackRange) {
                    Enemy enemy = enemyCollidersList[0].GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        StartCoroutine(enemy.DamageCharacter(damageStrength, 0f));
                    }
                }
            }
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
