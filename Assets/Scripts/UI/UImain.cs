using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImain : MonoBehaviour
{
    public GameObject settingScreen;
   
    public GameObject mainScreen;
    
    public void StartGame()
    {
        //Game Start
        SceneManager.LoadScene(1);
        Debug.Log("oyun başlıyor.");
    }
    public void Setting()
    {
        mainScreen.SetActive(false);
        settingScreen.SetActive(true);
    }
    public void SettingtoMenu()
    {
        mainScreen.SetActive(true);
        settingScreen.SetActive(false);
    }
    
    public void Exit()
    {
        Debug.Log("Çıkış Yapılıyor");
        Application.Quit();
    }
}
