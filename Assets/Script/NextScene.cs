using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public delegate void ProgressDelegate(float progress);

public class NextScene : MonoBehaviour
{
    public GameObject menuNextScene;
    public Button yes;
    public Button no;
    public GameObject Player;
    public GameObject teleport;
    public Animator cameraAnimator;
    public FollowPlayer followPlayerCamera;
    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        teleport.SetActive(false);
        menuNextScene.SetActive(false);
        yes.onClick.AddListener(Yes);
        no.onClick.AddListener(No);
    }

    void Yes(){
        StartCoroutine("Countdown");

    }

    IEnumerator Countdown()
    {
        menuNextScene.SetActive(false);
        Time.timeScale = 1;
        teleport.SetActive(true);
        //yield return new WaitForSeconds(1);
        followPlayerCamera.enabled = false;
        cameraAnimator.enabled = true;
        yield return new WaitForSeconds(5);
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }


    void No(){
        menuNextScene.SetActive(false);
        Time.timeScale = 1;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player)
        {
            menuNextScene.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
        }
    }    
}
