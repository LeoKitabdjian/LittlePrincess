using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityForTank : MonoBehaviour
{
    public float gravity = 9.81f;
    public Transform gravityTarget;
	public float autoOrientSpeed = 1f;
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody> ();
        rb.useGravity = false;
    }

    void Update()
    {
        Vector3 diff = transform.position - gravityTarget.position;
		rb.AddForce(-diff.normalized * gravity * (rb.mass));
    }
}
