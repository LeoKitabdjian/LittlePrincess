using UnityEngine;

public class CarController : CarBaseController
{
    protected override void Start()
    {
        base.Start();
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
    }
}
