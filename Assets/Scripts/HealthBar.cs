using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image HealthBarIMG;
    public float CurrentHealth;
    private float MaxHealth = 100f;
    PlayerMovement Player;
    // Start is called before the first frame update
    void Start()
    {
        HealthBarIMG = GetComponent<Image>();
        Player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = Player.playerHitPoints;
        HealthBarIMG.fillAmount = CurrentHealth / MaxHealth;
    }
}
