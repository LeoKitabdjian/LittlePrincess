using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManagerScene2 : MonoBehaviour
{
    public GameObject menu;
    public Button resumeButton;
    public Button quitButton;
    public Button reloadButton;
    private bool isPaused = false;

    void Start()
    {
        menu.SetActive(false);
        resumeButton.onClick.AddListener(ResumeTheGame);
        quitButton.onClick.AddListener(QuitTheGame);
        reloadButton.onClick.AddListener(ReloadTheGame);
    }

    void ResumeTheGame()
    {
        isPaused = false;
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    void QuitTheGame()
    {
        Application.Quit();
    }

    void ReloadTheGame()
    {
        isPaused = false;
        menu.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                menu.SetActive(true);
                Time.timeScale = 0;
                Cursor.visible = true;
            }
            else
            {
                menu.SetActive(false);
                Time.timeScale = 1;
                Cursor.visible = false;
            }
        }
    }
}
