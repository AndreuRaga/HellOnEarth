using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public StatPoints hitPoints;
    public virtual IEnumerator DamageCharacter(int damage, float interval)
    {
        while (true)
        {
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
        Destroy(gameObject);
    }
    public virtual void ResetCharacter()
    {
        hitPoints.currentValue = hitPoints.maxValue;
    }
}
