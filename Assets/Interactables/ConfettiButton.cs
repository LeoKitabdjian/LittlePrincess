using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfettiButton : MonoBehaviour, IInteractable
{
    public Canvas canvas;

    public ConfettiManager confetti;

    public bool Interact(Interactor interactor)
    {
        confetti.PlayConfetti();
        //Destroy(this);
        return true;
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
