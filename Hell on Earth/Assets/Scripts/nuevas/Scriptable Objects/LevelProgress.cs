using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LevelProgress", menuName = "LevelProgress")]
public class LevelProgress : ScriptableObject
{
    public int enemiesKilled;
    public int enemyCount;
    public float percentageKilled
    {
        get
        {
            if (enemyCount > 0)
            {
                return Mathf.Round(((float) enemiesKilled / enemyCount) * 100);
            }
            return 100;
        }
    }
}
