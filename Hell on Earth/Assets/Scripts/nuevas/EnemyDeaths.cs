using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyDeaths : MonoBehaviour
{
    public TextMeshProUGUI percentage;
    public LevelProgress LevelProgress;

    void Start()
    {
        // Encontrar todos los GameObjects con la etiqueta "Enemy"
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        LevelProgress.enemyCount = enemyList.Length;
        //Debug.Log("Cantidad de enemigos: " + enemyCount);
    }
    void Update()
    {
        if (LevelProgress.enemyCount <= 0)
        {
            percentage.text = "NE";
        }
        else
        {
            percentage.text = LevelProgress.percentageKilled.ToString() + "%";
        }
    }
}
