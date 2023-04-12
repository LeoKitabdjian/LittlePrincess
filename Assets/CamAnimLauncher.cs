using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAnimLauncher : MonoBehaviour
{
    public Animator animation;
    public FollowPlayer cam;
    public GameObject road;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LaunchAnim());
    }

    IEnumerator LaunchAnim()
    {
        cam.enabled = false;
        yield return new WaitForSeconds(0.5f);
        Destroy(road);
        animation.enabled = true;
        yield return new WaitForSeconds(3);
        animation.enabled = false;
        cam.enabled = true;
    }
}
