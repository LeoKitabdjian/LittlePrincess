using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;
    public Button resumeButton;
    public Button quitButton;
    private bool isPaused = false;

    void Start()
    {
        menu.SetActive(false);
        resumeButton.onClick.AddListener(ResumeTheGame);
        quitButton.onClick.AddListener(QuitTheGame);
    }

    void ResumeTheGame(){
        isPaused = false;
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    void QuitTheGame(){
        Application.Quit();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            isPaused = !isPaused;
            if(isPaused){
                menu.SetActive(true);
                Time.timeScale = 0;
                Cursor.visible = true;
            }else{
                menu.SetActive(false);
                Time.timeScale = 1;
                Cursor.visible = false;
            }
        }
    }
}
