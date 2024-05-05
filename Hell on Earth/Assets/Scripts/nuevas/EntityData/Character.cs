using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public StatPoints hitPoints;
    public LevelProgress levelProgress;
    public virtual IEnumerator DamageCharacter(int damage, float interval)
    {
        while (true)
        {
            StartCoroutine(FlickerCharacter());
            hitPoints.currentValue -= damage;
            if (hitPoints.currentValue <= 0)
            {
                hitPoints.currentValue = 0;
                KillCharacter();
                break;
            }
            if (interval > 0.0f)
            {
                yield return new WaitForSeconds(interval);
            }
            else
            {
                break;
            }
        }
    }
    public virtual void KillCharacter()
    {
        if (levelProgress != null && gameObject.CompareTag("Enemy"))
        {
            levelProgress.enemiesKilled++;
        }
        Destroy(gameObject);
    }
    public virtual void ResetCharacter()
    {
        hitPoints.currentValue = hitPoints.maxValue;
    }
    public virtual IEnumerator FlickerCharacter()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
    }

}
