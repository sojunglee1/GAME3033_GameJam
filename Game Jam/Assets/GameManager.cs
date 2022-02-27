using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject letter;
    public GameObject PauseMenu;

    public GameObject FadeOverlay;
    public Animator animator;
    public AudioSource audioSource;

    public readonly int Fade = Animator.StringToHash("Fade");
    public readonly int UnFade = Animator.StringToHash("UnFade");

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(PlayUnFadeAnimation());
        audioSource.volume = 0;

        letter.GetComponent<Animator>().Play("OpenLetter");

    }

    private void Update()
    {
        StartCoroutine(StartMusic());
    }

    public void GoToGame()
    {
        StartCoroutine(PlayFadeAnimation("Game"));
    }

    public void GoToMainMenu()
    {
        StartCoroutine(PlayFadeAnimation("Main Menu"));
    }

    IEnumerator PlayUnFadeAnimation()
    {
        animator.Play("UnFadeAnimation");
        yield return new WaitForSeconds(1.25f);
    }

    public IEnumerator PlayFadeAnimation(string sceneName)
    {
        animator.Play("FadeAnimation");
        yield return new WaitForSeconds(1.25f);
        SceneManager.LoadScene(sceneName);
    }

    public IEnumerator StartMusic()
    {
        yield return new WaitForSeconds(1f);
        if (audioSource.volume < 1.0f)
        {
            audioSource.volume += Time.deltaTime * 0.25f;
        }
    }

    public static void SetPause(bool pause)
    {
        if (pause) Time.timeScale = 0;
        else Time.timeScale = 1;
    }

    public static bool isGamePaused()
    {
        if (Time.timeScale.Equals(0)) return true;
        else return false;
    }

    public bool isLetterShowing()
    {
        return letter.gameObject.activeSelf;
    }

    public void CloseLetter()
    {
        letter.GetComponent<Animator>().Play("CloseLetter");
        letter.gameObject.SetActive(false);
    }

    public void Pause()
    {
        PauseMenu.SetActive(!PauseMenu.activeSelf);
        SetPause(PauseMenu.activeSelf);
    }
}
