using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void OnGoToMainMenu()
    {
        GameManager.Instance.pause = false;
        GameManager.Instance.GoToMainMenu();
    }
    public void OnQuit()
    {
        GameManager.Instance.Quit();
    }
}
