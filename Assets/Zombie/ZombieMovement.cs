using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{

    public float gravity = 9.81f;
    public Transform gravityTarget;
    public float autoOrientSpeed = 1f;
    public List<ZombieCheckpoint> targets;
    public float speed = 1.0f;
    private Rigidbody rb;
    private int currentCheckPoint = 0;
    public bool verbose;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ListenZombieCheckpoints();
    }

    private void ListenZombieCheckpoints()
    {
        foreach (ZombieCheckpoint z in targets)
        {
            z.onZombieCheckpointEnter.AddListener(ZombieCheckpointActivated);
        }
    }

    public void ZombieCheckpointActivated(ZombieMovement z, ZombieCheckpoint c)
    {
        if (z == this && Target() == c)
        {
            if (Target().rotate == true)
                transform.Rotate(0, 180, 0);
            if (verbose)
            {
                Debug.Log("je me dirige vers " + currentCheckPoint);
                Debug.Log("y'a " + targets.Count + " checkpoints");
            }
            if (currentCheckPoint >= targets.Count - 1)
                currentCheckPoint = 0;
            else
            {
                if (Target() == c)
                {
                    if (verbose)
                        Debug.Log("j'incrémente");
                    currentCheckPoint++;
                }
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (verbose)
            Debug.Log(currentCheckPoint);
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Target().transform.position, step);
        ProcessGravity();
        //transform.LookAt(targets[currentCheckPoint].transform);
    }

    void ProcessGravity()
    {
        Vector3 diff = transform.position - gravityTarget.position;
        rb.AddForce(-diff.normalized * gravity * (rb.mass));
        AutoOrient(-diff);
    }

    void AutoOrient(Vector3 down)
    {
        Quaternion orientationDirection = Quaternion.FromToRotation(-transform.up, down) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, orientationDirection, autoOrientSpeed * Time.deltaTime);
    }

    ZombieCheckpoint Target()
    {
        return targets[currentCheckPoint];
    }
}
