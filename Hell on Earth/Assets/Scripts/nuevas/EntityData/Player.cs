using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : DatosEntidad
{
    private void Start()
    {
        hitPoints.currentValue = hitPoints.maxValue;
    }
    public override string bubble()
    {
        throw new System.NotImplementedException();
    }

    public override void inter()
    {
        throw new System.NotImplementedException();
    }
}