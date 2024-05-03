using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LevelProgress", menuName = "LevelProgress")]
public class LevelProgress : ScriptableObject
{
    public int enemiesKilled;
    public int enemyCount;
    public int percentageDefeated
    {
        get
        {
            if (enemyCount > 0)
            {
                return (enemiesKilled / enemyCount) * 100;
            }
            return 100;
        }
    }
}
