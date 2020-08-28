using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public TextMeshProUGUI text;
    PlayerMovement Player;

    public float coinCount;

    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        coinCount = Player.coinCounter;
        text.text = coinCount.ToString() + "/3";
    }
}
