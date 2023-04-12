using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CarController : CarBaseController
{

    [SerializeField]
    private AudioClip accelerationSound;
    private AudioSource audioSource;
    private bool wasAccelerating;

    protected override void Start()
    {
        base.Start();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && IsUpsideDown())
        {
            FlipCar();
        }
    }

    private bool IsUpsideDown()
    {
        return Vector3.Dot(transform.up, Vector3.down) > 0.5f;
    }

    private void FlipCar()
    {
        // Change la position de la voiture légèrement vers le haut pour éviter les problèmes de collision
        transform.position += Vector3.up * 2.0f;
        // Réinitialise la rotation de la voiture
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        // Réinitialise la vélocité de la voiture pour éviter des mouvements brusques après avoir été retournée
        rb.velocity = Vector3.zero;
    }

    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");

        if (rb.velocity.magnitude < maxSpeed)
        {
            Vector3 movement = transform.forward * moveVertical;
            rb.AddForce(movement * acceleration);
        }

        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);

        if (rotation != 0)
        {
            rb.velocity = rb.velocity * speedDecayFactor;
        }

        // Joue le son d'accélération si la voiture accélère
        bool isAccelerating = Mathf.Abs(moveVertical) > 0.1f;
        if (isAccelerating && !wasAccelerating)
        {
            audioSource.PlayOneShot(accelerationSound);
        }

        wasAccelerating = isAccelerating;

    }


}
