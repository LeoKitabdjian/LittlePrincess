using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{

    public float gravity = 9.81f;
    public Transform gravityTarget;
    public float autoOrientSpeed = 0f;
    public List<ZombieCheckpoint> targets;
    public float speed = 1.0f;
    private Rigidbody rb;
    private int currentCheckPoint = 0;
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

    public void ZombieCheckpointActivated(ZombieMovement z)
    {
        if (currentCheckPoint >= targets.Count - 1)
        {
            currentCheckPoint = 0;
        }
        else
        {
            currentCheckPoint++;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targets[currentCheckPoint].transform.position, step);
        transform.LookAt(targets[currentCheckPoint].transform);
        ProcessGravity();
    }

    void ProcessGravity()
    {
        Vector3 diff = transform.position - gravityTarget.position;
        rb.AddForce(-diff.normalized * gravity * (rb.mass));
        //AutoOrient(-diff);
    }

    void AutoOrient(Vector3 down)
    {
        Quaternion orientationDirection = Quaternion.FromToRotation(-transform.up, down) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, orientationDirection, autoOrientSpeed * Time.deltaTime);
    }
}
