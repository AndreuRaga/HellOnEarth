using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyDeaths : MonoBehaviour
{
    public TextMeshProUGUI percentage;
    public LevelProgress levelProgress;

    void Start()
    {
        // Encontrar todos los GameObjects con la etiqueta "Enemy"
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        levelProgress.enemyCount = enemyList.Length;
        levelProgress.enemiesKilled = 0;
    }
    void Update()
    {
        if (levelProgress.enemyCount <= 0)
        {
            percentage.text = "NE";
        }
        else
        {
            percentage.text = levelProgress.percentageKilled.ToString() + "%";
        }
    }
}
