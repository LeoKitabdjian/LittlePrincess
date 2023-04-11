using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConfettiButton : MonoBehaviour, IInteractable
{
    public Canvas canvas;

    public ConfettiManager confetti;

    public Image blackScreen;

    private bool hasStarted = false;

    public float fadeSpeed;

    void Start()
    {
        StartCoroutine(FadeToBlack());
    }

    public bool Interact(Interactor interactor)
    {
        confetti.PlayConfetti();
        if (!hasStarted)
        {
            StartCoroutine(FadeToBlack());
            hasStarted = true;
        }
        //Destroy(this);
        return true;
    }

    private IEnumerator FadeToBlack()
    {
        Color objectColor = blackScreen.color;
        float fadeAmount;
        while (blackScreen.color.a < 1) 
        {
            fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);
            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            blackScreen.color = objectColor;
            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ShowAction()
    {
        canvas.enabled = true;
    }

    public void HideAction()
    {
        canvas.enabled = false;
    }
}
