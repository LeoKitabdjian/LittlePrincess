using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    public Rigidbody carRigidbody;
    public float speedThreshold = 1f;
    private ParticleSystem particleSystem;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (carRigidbody.velocity.magnitude > speedThreshold)
        {
            if (!particleSystem.isPlaying)
            {
                particleSystem.Play();
            }
        }
        else
        {
            if (particleSystem.isPlaying)
            {
                particleSystem.Stop();
            }
        }
    }
}
