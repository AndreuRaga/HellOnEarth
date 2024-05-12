using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public AudioClip firstLevelTheme;
    public AudioClip secondLevelTheme;  
    private const int FIRST_LEVEL_INDEX = 2;
    private const int SECOND_LEVEL_INDEX = 3;
    void Start()
    {
        if (firstLevelTheme != null && SceneManager.GetActiveScene().buildIndex == FIRST_LEVEL_INDEX)
        {
            GameManager.Instance.audioManager.PlayMusic(firstLevelTheme);
        }
        else if (secondLevelTheme != null && SceneManager.GetActiveScene().buildIndex == SECOND_LEVEL_INDEX)
        {
            GameManager.Instance.audioManager.PlayMusic(secondLevelTheme);
        }
        GameManager.Instance.pause = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.pause = !GameManager.Instance.pause;
        }
        if (!PlayerExists())
        {
            GameManager.Instance.pause = true;
        }
    }
    private bool PlayerExists()
    {
        // Buscar todos los GameObjects con la etiqueta "Player" en la escena
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        return players.Length > 0;
    }
}
