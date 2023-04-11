using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public GameObject[] waypoints;
    public float waypointRadius = 5f;
    

    void Start()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogError("Aucun point de passage défini. Veuillez les ajouter dans l'inspecteur.");
        }
    }

    public int GetNextWaypointIndex(int currentWaypointIndex)
    {
        int nextWaypointIndex = currentWaypointIndex + 1;
        if (nextWaypointIndex >= waypoints.Length)
        {
            nextWaypointIndex = 0;
        }
        return nextWaypointIndex;
    }

    public GameObject GetWaypointAtIndex(int index)
    {
        if (index < 0 || index >= waypoints.Length)
        {
            Debug.LogError("Index de point de passage invalide.");
            return null;
        }
        return waypoints[index];
    }

    public int GetTotalWaypoints()
    {
        return waypoints.Length;
    }
    
    public Transform GetWaypoint(int index)
    {
        if (index < 0 || index >= waypoints.Length)
        {
            Debug.LogError("L'index du waypoint est hors limites.");
            return null;
        }

        return waypoints[index].transform; // Ajoutez '.transform' ici
    }
    
    
}
