using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearControl : MonoBehaviour
{
    public bool feared = false;
    public float fearAmount = 0f;
    FearAura[] fearAuras;

    // Start is called before the first frame update
    void Start()
    {
        fearAuras = GameObject.FindObjectsOfType<FearAura>();
        foreach (FearAura f in fearAuras)
        {
            f.onFearAuraEnter.AddListener(IsFeared);
            f.onFearAuraExit.AddListener(IsNotFeared);
        }
    }

    void IsFeared(FearControl f)
    {
        feared = true;
    }

    void IsNotFeared(FearControl f)
    {
        feared = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (feared)
        {
            fearAmount += 0.33f;
        }
        Debug.Log(fearAmount);
    }
}
