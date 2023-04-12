using System.Collections.Generic;
using UnityEngine;

public class SupporterDuplicator : MonoBehaviour
{
    public GameObject objectToDuplicate; // L'objet que vous souhaitez dupliquer
    public List<Transform> spawnPoints; // La liste des points où les objets seront dupliqués

    void Start()
    {
        DuplicateObject();
    }

    void DuplicateObject()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            // Dupliquer l'objet à chaque point de spawn
            GameObject duplicatedObject = Instantiate(objectToDuplicate, spawnPoint.position, spawnPoint.rotation);

            // Ajouter l'objet dupliqué en tant qu'enfant du point de spawn (facultatif)
            duplicatedObject.transform.SetParent(spawnPoint);
        }
    }
}
