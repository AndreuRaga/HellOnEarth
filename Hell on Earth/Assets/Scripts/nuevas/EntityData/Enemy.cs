using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public int damageStrength;
    Coroutine damageCoroutine;
    public LevelProgress levelProgress;
    public AudioClip enemyDeath;
    private void OnEnable()
    {// Llamada cada vez que se habilita o activa el gameobject
        hitPoints = Instantiate(hitPoints);
        ResetCharacter();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (damageCoroutine == null)
            {
                damageCoroutine = StartCoroutine(player.DamageCharacter(damageStrength, 1.0f));
            }
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
    }
    public override void KillCharacter()
    {
        if (levelProgress != null)
        {
            if (enemyDeath != null)
            {
                GameManager.Instance.audioManager.PlaySound(enemyDeath);
            }
            levelProgress.enemiesKilled++;
        }
        base.KillCharacter();
    }
}
