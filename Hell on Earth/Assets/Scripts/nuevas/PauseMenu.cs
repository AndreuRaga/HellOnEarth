using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public void OnGoToMainMenu()
    {
        Debug.Log("pulsado");
        GameManager.Instance.pause = false;
        GameManager.Instance.GoToMainMenu();
    }
    public void OnOptions()
    {
        if (optionsMenu != null)
        {
            optionsMenu.SetActive(!optionsMenu.activeSelf);
        }
    }
    public void OnQuit()
    {
        GameManager.Instance.Quit();
    }
}
