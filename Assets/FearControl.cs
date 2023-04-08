using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearControl : MonoBehaviour
{
    public bool feared = false;
    public float fearAmount = 0f;
    FearAura[] fearAuras;
    public FearBar fearBar;

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
        if (fearAmount >= 100)
        {
            this.transform.position = new Vector3(5, 73.2f, 8);
            this.transform.rotation = new Quaternion(0, -180, 12, 0);
            fearAmount = 0f;
        }
        fearBar.setFear(fearAmount);
    }
}
