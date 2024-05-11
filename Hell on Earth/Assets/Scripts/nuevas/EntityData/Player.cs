using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public int damageStrength;
    public float attackRange;
    private Animator animator;
    public AudioClip playerDeath;

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
            // Iniciar la animación de ataque
            animator.SetTrigger("Attack");
            // Detener temporalmente el movimiento del jugador durante la animación de ataque
            movementController.StopMovementTemporarily(GetAttackAnimationDuration());
            //Centro o posición de Player
            Vector2 centro = transform.position;
            // Definir el filtro para solo colisionar con GameObjects que tengan la etiqueta "Enemies"
            ContactFilter2D contactFilter = new ContactFilter2D();
            contactFilter.SetLayerMask(LayerMask.GetMask("Enemies"));
            contactFilter.useLayerMask = true;
            //colliders enemigos
            List<Collider2D> enemyCollidersList = new List<Collider2D>();
            Physics2D.OverlapCircle(centro, attackRange, contactFilter, enemyCollidersList);
            if (enemyCollidersList.Count > 0)
            {
                foreach (Collider2D enemyCollider in enemyCollidersList) { 
                    Vector2 enemyPosition = enemyCollider.transform.position;
                    //Distancia entre Player y enemigo
                    Vector2 distance = (enemyPosition - centro).normalized;
                    //Poner aquí la dirección en la que mira Player
                    Vector2 playerDirection = GetComponent<MovementController>().movement.normalized;
                    //Debug.Log(playerDirection.ToString());

                    if (Vector2.Dot(distance, playerDirection) >= Math.Cos(20*Math.PI/180)) { //Comprueba que Player mira en la dirección del enemigo
                        Debug.Log("HIT");
                        Enemy enemy = enemyCollider.GetComponent<Enemy>();
                        if (enemy != null)
                        {
                            StartCoroutine(enemy.DamageCharacter(damageStrength, 0f));
                        }
                    } else
                        Debug.Log("NOT HIT");
                }
            }
        }
    }

    // Método para obtener la duración de la animación de ataque
    private float GetAttackAnimationDuration()
    {
        // Suponiendo que "Attack" es el nombre del estado de la animación de ataque
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
    public override void KillCharacter()
    {
        if (playerDeath != null)
        {
            GameManager.Instance.audioManager.PlaySound(playerDeath);
        }
        base.KillCharacter();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CanBePickedUp"))
        {
            HealthPotion healthPotion = other.gameObject.GetComponent<HealthPotion>();
            if (healthPotion != null)
            {
                if (hitPoints.currentValue < hitPoints.maxValue)
                {
                    AdjustHitPoints(healthPotion.hpRestored);
                    other.gameObject.SetActive(false);
                }
            }
        }
    }
    public void AdjustHitPoints(int amount)
    {
        hitPoints.currentValue += amount;
    }
}
