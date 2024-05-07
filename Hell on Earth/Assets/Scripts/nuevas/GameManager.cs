using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioManager))]
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
    [SerializeField] GameObject pauseMenu;
    private bool paused = false;
    public bool pause {
        get {
            return paused;
        }
        set {
            paused = value;
            if (paused)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
        }
    }
    const int MAIN_MENU_SCENE_INDEX = 1;
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(MAIN_MENU_SCENE_INDEX);
    }
    public AudioManager audioManager;
    public override void Awake()
    {
        base.Awake();
        audioManager = GetComponent<AudioManager>();
    }
    void Start()
    {
        SetupScene();
    }

    void SetupScene()
    {
        SpawnPlayer();
    }
    public SpawnPoint playerSpawnPoint;
    void SpawnPlayer()
    {
        if (playerSpawnPoint != null)
        {
            GameObject player = playerSpawnPoint.SpawnObject();
        }
    }
}
