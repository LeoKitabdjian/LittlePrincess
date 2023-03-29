using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FearAura : MonoBehaviour
{
    public UnityEvent<FearControl> onFearAuraEnter;
    public UnityEvent<FearControl> onFearAuraExit;

    void OnTriggerEnter(Collider collider)
    {
        FearControl fearControl = collider.gameObject.GetComponent<FearControl>();
        if (fearControl != null)
        {
            onFearAuraEnter.Invoke(fearControl);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        FearControl fearControl = collider.gameObject.GetComponent<FearControl>();
        if (fearControl != null)
        {
            onFearAuraExit.Invoke(fearControl);
        }
    }
}
