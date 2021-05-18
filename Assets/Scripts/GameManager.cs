using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static bool isGameOver = false;
    Volume volume;
    public static bool isGameRunning = true;
    Vignette vignette;
    public static List<GameObject> ObjectToFollow= new List<GameObject>();
    float timer = 0f;
    public static int deathCount = 0;
    [SerializeField] Text gameLostText;
    bool gameEnd = false;
    public bool IsGameLost { get; set; }

    private void Awake()
    {
        isGameOver = false;
        isGameRunning = true;
        IsGameLost = false;
        ObjectToFollow.Clear();
        volume = FindObjectOfType<Volume>();
        volume.sharedProfile.TryGet<Vignette>(out vignette);
    }
    private void Start()
    {
        vignette.intensity.Override(0f);
        gameLostText.color = new Color(1f, 1f, 1f, 0f);
    }
    private void Update()
    {
        if (IsGameLost)
        {
            DoGameLostText();
            DoVignette();
            if (!gameEnd)
            {
                gameEnd = true;
                GameLost();
                StartCoroutine(EndGame());
            }
        }
    }
    public void GameWon()
    {
        isGameOver = true;
        isGameRunning = false;
    }
    public void GameLost()
    {
        isGameOver = true;
        isGameRunning = false;
        IsGameLost = true;
    }

    private void DoVignette()
    {
        timer += (Time.deltaTime / 4);
        if (timer >= 1f) { timer = 1f;  }
        vignette.intensity.Override(timer);
    }
    private void DoGameLostText()
    {
        float alpha = Mathf.Clamp(timer*1.2f, 0f, 1f);
        gameLostText.color = new Color(0f, 0f, 0f, alpha);
    }
    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }

}
