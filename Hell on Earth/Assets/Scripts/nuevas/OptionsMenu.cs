using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private Slider masterVolume;
    [SerializeField] private Slider musicVolume;
    [SerializeField] private Slider sfxVolume;
    private void Start()
    {
        masterVolume.value = GameManager.Instance.audioManager.GetMasterVolume();
        musicVolume.value = GameManager.Instance.audioManager.GetMusicVolume();
        sfxVolume.value = GameManager.Instance.audioManager.GetSFXVolume();
    }
    public void OnMasterVolumeChanged()
    {
        GameManager.Instance.audioManager.SetMasterVolume(masterVolume.value);
    }
    public void OnMusicVolumeChanged()
    {
        GameManager.Instance.audioManager.SetMusicVolume(musicVolume.value);
    }
    public void OnSFXVolumeChanged()
    {
        GameManager.Instance.audioManager.SetSFXVolume(sfxVolume.value);
    }
}
