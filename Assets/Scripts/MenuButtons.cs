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
        //Reset.coinCounter = 0;
        //Reset.playerHitPoints = 100;
        SceneManager.LoadScene("SampleScene");
        
    }
    public void EnterGameOver()
    {
        SceneManager.LoadScene("DeathScreen");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
