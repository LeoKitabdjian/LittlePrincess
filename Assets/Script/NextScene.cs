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

    // Start is called before the first frame update
    void Start()
    {
        menuNextScene.SetActive(false);
        yes.onClick.AddListener(Yes);
        no.onClick.AddListener(No);
    }

    void Yes(){
        menuNextScene.SetActive(false);
        Time.timeScale = 1;
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);

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
