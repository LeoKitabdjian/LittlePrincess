using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiManager : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public AudioSource conffetiSound;
    // Start is called before the first frame update
    void Start()
    {
        particleSystem.Stop(true);
        //particleSystem.Play(true);
    }

    public void PlayConfetti()
    {
        conffetiSound.Play();
        particleSystem.Play(true);
    }
}
