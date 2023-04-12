using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] public Transform interactionPoint;
    [SerializeField] public float interactionPointRadius = 0.5f;
    [SerializeField] public LayerMask interactableMask;

    private Collider[] colliders = new Collider[1];
    [SerializeField] private int numFound;

    private IInteractable interactable;
    // Update is called once per frame
    void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.transform.position, interactionPointRadius, colliders, interactableMask);

        if (numFound > 0)
        {
            interactable = colliders[0].GetComponent<IInteractable>();
            if (interactable != null) 
            {
                interactable.ShowAction();
                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    interactable.Interact(this);
                }
            }
        }
        else
        {
            if (interactable != null)
            {
                interactable.HideAction();
                interactable = null;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
    }
}
