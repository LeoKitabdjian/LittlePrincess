using UnityEngine;

public class SceneTeleporter : MonoBehaviour
{
    [SerializeField] private string targetSceneName;
    public GameObject player;
    public SceneFader sceneFader;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            StartCoroutine(sceneFader.FadeAndLoadScene(targetSceneName));
        }
    }
}
