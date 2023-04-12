using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAnimLauncher : MonoBehaviour
{
    public Animator animation;
    public FollowPlayer cam;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LaunchAnim());
    }

    IEnumerator LaunchAnim()
    {
        animation.enabled = true;
        yield return new WaitForSeconds(3);
        animation.enabled = false;
        cam.followPlayer = true;
    }
}
