using UnityEngine;

public class CarAIController : CarBaseController
{
    public float steerSensitivity = 0.01f;
    public float distanceToWaypointThreshold = 3.0f;
    public float rotationSmoothness = 5f; // Augmentez cette valeur pour rendre la rotation plus fluide
    public WaypointManager waypointManager;
    private Transform targetWaypoint;
    

    void Start()
    {
        if (waypointManager == null)
        {
            Debug.LogError("WaypointManager non assigné. Veuillez l'ajouter dans l'inspecteur.");
        }
        else
        {
            currentWaypointIndex = 0;
            targetWaypoint = waypointManager.GetWaypoint(currentWaypointIndex);
        }
    }


    void FixedUpdate()
    {
        if (waypointManager != null)
        {
            float step = acceleration * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, step);

            // Ajoutez une interpolation pour adoucir la rotation
            Quaternion targetRotation = Quaternion.LookRotation(targetWaypoint.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothness * Time.deltaTime);

            float distanceToWaypoint = Vector3.Distance(transform.position, targetWaypoint.position);
            if (distanceToWaypoint <= waypointManager.waypointRadius)
            {
                UpdateCurrentWaypoint();
                targetWaypoint = waypointManager.GetWaypoint(currentWaypointIndex);
            }
        }
    }



    private void OnTriggerEnteredWaypoint()
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

    private void UpdateCurrentWaypoint()
    {
        currentWaypointIndex++;
        if (currentWaypointIndex >= waypointManager.waypoints.Length) // Remplacez 'Count' par 'Length'
        {
            currentWaypointIndex = 0;
        }
    }


}

 