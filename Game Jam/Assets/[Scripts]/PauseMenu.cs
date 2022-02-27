using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Slider volumeSlider;

    public void Start()
    {
        volumeSlider.value = AudioListener.volume;
    }
    private void Update()
    {
        AudioListener.volume = volumeSlider.value;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        GameManager.instance.GoToMainMenu();
    }

    public void ResumeGame()
    {
        GameManager.SetPause(false);
        GameManager.instance.PauseMenu.SetActive(false);
    }
}
