using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZombieCheckpoint : MonoBehaviour
{
    public UnityEvent<ZombieMovement, ZombieCheckpoint> onZombieCheckpointEnter;
    public bool rotate;

    void OnTriggerEnter(Collider collider)
    {
        ZombieMovement zombie = collider.gameObject.GetComponent<ZombieMovement>();
        if (zombie != null)
        {
            if (zombie.targets.Contains(this))
            {
                onZombieCheckpointEnter.Invoke(zombie, this);
            }
        }
    }
}
