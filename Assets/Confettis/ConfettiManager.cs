using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiManager : MonoBehaviour
{
    public ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        particleSystem.Stop(true);
        //particleSystem.Play(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
