using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuButtons : MonoBehaviour
{
    PlayerMovement Reset;

    void Start()
    {
        Reset = FindObjectOfType<PlayerMovement>();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("StartScreen");
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
        Time.timeScale = 1f;
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("SampleScene");
        Reset.coinCounter = 0;
        Reset.playerHitPoints = 100;
    }
}
