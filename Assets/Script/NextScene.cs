using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        FreezePlayer(false);
        SceneManager.LoadScene(nextSceneIndex);
    }


    void No(){
        menuNextScene.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        FreezePlayer(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player)
        {
            menuNextScene.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            FreezePlayer(true);
        }
    }

    void FreezePlayer(bool freeze)
    {
        Player.SetActive(!freeze);
    }    
}
