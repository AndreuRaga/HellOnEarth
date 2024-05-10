using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject creditsPanel;
    public GameObject optionsMenu;
    public AudioClip titleTheme;
    private void Start()
    {
        if (titleTheme != null)
        {
            GameManager.Instance.audioManager.PlayMusic(titleTheme);
        }
        creditsPanel.SetActive(false);
        optionsMenu.SetActive(false);
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
