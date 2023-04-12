using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public bool Interact(Interactor interactor);
    public void ShowAction();
    public void HideAction();
}
