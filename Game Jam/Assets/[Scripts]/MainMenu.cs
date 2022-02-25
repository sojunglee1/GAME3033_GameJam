using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    public GameObject FadeOverlay;

    public List<Button> ListOfButtons = new List<Button>();

    private void Update()
    {
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
        StartCoroutine(PlayFadeAnimation());
        
    }

    IEnumerator PlayFadeAnimation()
    {
        FadeOverlay.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(1.25f);
        SceneManager.LoadScene("Game");
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