using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public int damageStrength;
    private void Start()
    {
        hitPoints.currentValue = hitPoints.maxValue;
    }
}