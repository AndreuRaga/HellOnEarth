using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyDeaths : MonoBehaviour
{
    public TextMeshProUGUI percentage;
    public int enemiesDead = 0;
    public int enemyCount = 0;
    public GameObject portal;

    void Start()
    {
        portal.SetActive(false);
        // Encontrar todos los GameObjects con la etiqueta "Enemy"
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = enemyList.Length;
        Debug.Log("Cantidad de enemigos: " + enemyCount);
    }
    void Update()
    {
        if (enemyCount <= 0)
        {
            percentage.text = "NE";
        }
        else
        {
            percentage.text = GetPercentageNumber().ToString() + "%";
        }
        if (GetPercentageNumber() >= 33)
        {
            portal.SetActive(true);
        }
    }
    private int GetPercentageNumber()
    {
        return (enemiesDead / enemyCount) * 100;
    }
}
