using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZombieCheckpoint : MonoBehaviour
{
    public UnityEvent<ZombieMovement> onZombieCheckpointEnter;

    void OnTriggerEnter(Collider collider)
    {
        ZombieMovement zombie = collider.gameObject.GetComponent<ZombieMovement>();
        onZombieCheckpointEnter.Invoke(zombie);
    }
}
