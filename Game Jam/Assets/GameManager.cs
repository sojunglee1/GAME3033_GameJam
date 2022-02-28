using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject StartingLetter;
    public GameObject EndingLetter;
    public GameObject PauseMenu;
    public GameObject DeathMenu;

    public GameObject FadeOverlay;
    public Animator animator;
    public AudioSource audioSource;

    public bool PlayerDied = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(PlayUnFadeAnimation());
        audioSource.volume = 0;

        StartingLetter.GetComponent<Animator>().Play("OpenLetter");

    }

    private void Update()
    {
        StartCoroutine(StartMusic());

        if (PlayerDied)
        {
            ShowDeathMenu();
        }
    }

    public void GoToGame()
    {
        PlayerDied = false;
        print("restarting game");
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

    IEnumerator EndMusic()
    {
        yield return null;
        if (audioSource.volume > 0.0f)
        {
            audioSource.volume += Time.deltaTime * -1.0f;
        }
    }
    public void FadeMusic()
    {
        StartCoroutine(EndMusic());
    }


    public void Pause()
    {
        PauseMenu.SetActive(!PauseMenu.activeSelf);
        SetPause(PauseMenu.activeSelf);
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
        return StartingLetter.gameObject.activeSelf || EndingLetter.gameObject.activeSelf;
    }

    public void CloseLetter()
    {
        if (StartingLetter.gameObject.activeSelf)
        {
            StartingLetter.GetComponent<Animator>().Play("CloseLetter");
            StartingLetter.gameObject.SetActive(false);
        }
        else if (EndingLetter.gameObject.activeSelf)
        {
            GoToMainMenu();
        }
    }

    public void ShowDeathMenu()
    {
        FadeMusic();
        DeathMenu.SetActive(true);
        DeathMenu.GetComponent<Animator>().Play("OpenDeathMenu");
    }

    public void ResetDeath()
    {
        PlayerDied = false ;
    }
}
