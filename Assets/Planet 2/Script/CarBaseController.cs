using UnityEngine;

public class CarBaseController : MonoBehaviour
{
    public float acceleration = 20f;
    public float maxSpeed = 80f;
    public float rotationSpeed = 80f;
    public float speedDecayFactor = 0.975f;
    protected Rigidbody rb;
    protected WaypointManager waypointManager;
    protected int currentWaypointIndex;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetWaypointManager(WaypointManager manager)
    {
        waypointManager = manager;
        currentWaypointIndex = 0;
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (waypointManager && other.gameObject == waypointManager.GetWaypointAtIndex(currentWaypointIndex))
        {
            int nextIndex = waypointManager.GetNextWaypointIndex(currentWaypointIndex);

            if (nextIndex == 0)
            {
                RaceManager raceManager = FindObjectOfType<RaceManager>();
                if (raceManager)
                {
                    raceManager.CarCompletedLap(this);
                }
            }

            currentWaypointIndex = nextIndex;
        }
    }
}
