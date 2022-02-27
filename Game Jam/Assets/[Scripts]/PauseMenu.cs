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
        GameManager.instance.FadeOverlay.GetComponent<Image>().enabled = true;
        GameManager.instance.FadeOverlay.GetComponent<Image>().color = new Color(0, 0, 0, 1);
        GameManager.instance.GoToMainMenu();
    }

    public void ResumeGame()
    {
        GameManager.SetPause(false);
        GameManager.instance.PauseMenu.SetActive(false);
    }
}
