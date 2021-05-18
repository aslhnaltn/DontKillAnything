using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Ingame : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject inGameScreen;

   
    public void PauseScreen()
    {
        Time.timeScale = 0f;
        inGameScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }
    public void InGameScreen()
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        inGameScreen.SetActive(true);

    }

    public void BackMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
