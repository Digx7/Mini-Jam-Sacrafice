using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_Zag : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public int menu = 0;
    public int reset = 1;


    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Play()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void MainMenu(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void Restart(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
