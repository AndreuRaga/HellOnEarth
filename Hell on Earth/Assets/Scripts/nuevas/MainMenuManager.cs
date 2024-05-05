using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    //public AudioClip mainMenuTheme;
    public GameObject creditsPanel;
    public GameObject optionsMenu;
    private void Start()
    {
        creditsPanel.SetActive(false);
        optionsMenu.SetActive(false);
        //if (mainMenuTheme != null)
        //    GameManager.Instance.audioManager.PlayMusic(mainMenuTheme);
    }
    public void StartGame()
    {
        GameManager.Instance.GoToNextLevel(0f);
    }
    public void Options()
    {
        if (optionsMenu != null)
        {
            optionsMenu.SetActive(!optionsMenu.activeSelf);
        }
    }
    public void Credits()
    {
        if (creditsPanel != null)
        {
            // Alternar la visibilidad del GameObject de créditos
            creditsPanel.SetActive(!creditsPanel.activeSelf);
        }
    }
    public void Quit()
    {
        GameManager.Instance.Quit();
    }
}
