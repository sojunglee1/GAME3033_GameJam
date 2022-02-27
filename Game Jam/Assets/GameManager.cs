using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject FadeOverlay;
    public Animator animator;
    public AudioSource audioSource;

    public readonly int Fade = Animator.StringToHash("Fade");
    public readonly int UnFade = Animator.StringToHash("UnFade");

    private void Start()
    {
        StartCoroutine(PlayUnFadeAnimation());
        audioSource.volume = 0;
    }

    private void Update()
    {
        StartCoroutine(StartMusic());
    }

    public void GoToGame()
    {
        StartCoroutine(FadeToGame());
    }

    IEnumerator PlayUnFadeAnimation()
    {
        animator.Play("UnFadeAnimation");
        yield return new WaitForSeconds(1.25f);
    }

    IEnumerator FadeToGame()
    {
        animator.Play("UnFadeAnimation");
        yield return new WaitForSeconds(1.25f);
        SceneManager.LoadScene("Game");
    }

    IEnumerator StartMusic()
    {
        yield return new WaitForSeconds(1f);
        if (audioSource.volume < 1.0f)
        {
            audioSource.volume += Time.deltaTime * 0.25f;
        }
    }
}
