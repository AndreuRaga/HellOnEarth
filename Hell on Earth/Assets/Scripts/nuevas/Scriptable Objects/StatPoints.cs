using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New StatPoints", menuName = "StatPoints")]
public class StatPoints : ScriptableObject
{
    public int currentValue;
    public int maxValue;
}
