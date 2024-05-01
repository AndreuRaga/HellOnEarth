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
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }
    }
}