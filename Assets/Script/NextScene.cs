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
    //audio
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        menuNextScene.SetActive(false);
        yes.onClick.AddListener(Yes);
        no.onClick.AddListener(No);
    }

    void Yes(){
        menuNextScene.SetActive(false);
        //int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        // if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
        // {
        //     // Load async
        // delete the audio source
        Destroy(audioSource);
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        // }
        //StartCoroutine(LoadYourAsyncScene());
    }

    IEnumerator LoadYourAsyncScene()
    {
        // AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0);
        // asyncLoad.allowSceneActivation = false;
        // while (asyncLoad.progress<0.9f)
        // {
        //     yield return null;
        // }
        // asyncLoad.allowSceneActivation = true;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        asyncLoad.allowSceneActivation = false;
        while (!asyncLoad.isDone)
        {
            print("Loading progress: " + (asyncLoad.progress * 100) + "%");
            if (asyncLoad.progress >= 0.5f){
                asyncLoad.allowSceneActivation = true;
            }
            yield return null;
        }
    }

    void No(){
        menuNextScene.SetActive(false);
        Time.timeScale = 1;
    }

    void OnTriggerEnter(Collider other)
    {
        menuNextScene.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
    }    
}
