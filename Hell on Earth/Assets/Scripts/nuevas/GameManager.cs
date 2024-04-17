using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public float interLevelWaitTime = 3f;
    public void GoToNextLevel(float waitTime = -1)
    {
        //Si llegas al último nivel
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            Debug.Log("YOU WIN!");
        }
        else
        {
            if (waitTime < 0) waitTime = interLevelWaitTime;
            Debug.Log("Prepare for next level!");
            StartCoroutine(WaitAndLoadNextScene(waitTime));
        }
    }
    private IEnumerator WaitAndLoadNextScene(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    void Start()
    {
        SetupScene();
    }

    void SetupScene()
    {

    }
}
