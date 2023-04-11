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

    public AudioSource bgMusic;

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
        float soundValue;
        while (blackScreen.color.a < 1) 
        {
            //Screen fade to black
            fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);
            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            blackScreen.color = objectColor;

            //Reduce background music volume
            soundValue = bgMusic.volume - (fadeSpeed / 10 * Time.deltaTime);
            bgMusic.volume = soundValue;
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
