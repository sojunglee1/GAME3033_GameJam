using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    public GameObject FadeOverlay;
    public Animator animator;
    public AudioSource audioSource;

    public List<Button> ListOfButtons = new List<Button>();

    private bool fadeMusic = false;

    private void Start()
    {
        StartCoroutine(PlayUnFadeAnimation());
        audioSource.volume = 0;
    }

    private void Update()
    {
        SetMusic(fadeMusic);

        foreach (Button buttonObject in ListOfButtons)
        {
            SetHoverMaterial(buttonObject.buttonObject, buttonObject.defaultMaterial, buttonObject.hoverMaterial);

            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            if (Mouse.current.leftButton.isPressed)
            {
                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.Equals(buttonObject.buttonObject.gameObject))
                {
                    buttonObject.customEvent.Invoke();
                    SetMaterial(buttonObject.buttonObject, buttonObject.clickedMaterial);
                }
            }
        }
    }

    public void SetMaterial(GameObject buttonObject, Material newMaterial)
    {
        for (int i = 0; i < buttonObject.transform.childCount; i++)
        {
            buttonObject.transform.GetChild(i).GetComponent<MeshRenderer>().material = newMaterial;
        }
    }

    public void SetHoverMaterial(GameObject buttonObject, Material defaultMaterial, Material hoveredMaterial)
    {

        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.Equals(buttonObject.gameObject))
        {
            SetMaterial(buttonObject, hoveredMaterial);
        }
        else
        {
            SetMaterial(buttonObject, defaultMaterial);
        }
    }

    public void GoToGame()
    {
        fadeMusic = true;
        StartCoroutine(FadeToGame());
    }

    public void FadeMusic()
    {
        StartCoroutine(EndMusic());
    }

    IEnumerator PlayUnFadeAnimation()
    {
        animator.Play("UnFadeAnimation");
        yield return new WaitForSeconds(1.25f);
    }

    IEnumerator FadeToGame()
    {
        animator.Play("FadeAnimation");
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

    IEnumerator EndMusic()
    {
        yield return null;
        if (audioSource.volume > 0.0f)
        {
            audioSource.volume += Time.deltaTime * -1.0f;
        }
    }

    public void SetMusic(bool fade)
    {
        if (fade)
        {
            StartCoroutine(EndMusic());
        }
        else StartCoroutine(StartMusic());
    }

    public void QuitGame()
    {
        StartCoroutine(Quit());
    }

    public IEnumerator Quit()
    {
        animator.Play("FadeAnimation");
        yield return new WaitForSeconds(1.25f);

#if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

[System.Serializable]
public class Button
{ 
    public GameObject buttonObject;
    public Material defaultMaterial;
    public Material clickedMaterial;
    public Material hoverMaterial;
    public UnityEvent customEvent = new UnityEvent();
}