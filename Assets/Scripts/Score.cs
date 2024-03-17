using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject player;
    public Text scoreText;
    public Text coinText;
    int coinAmount = 0;
    float maxScore = 0f;
    float score = 0f;

    public void Start()
    {
        coinAmount = PlayerPrefs.GetInt("Coin", 0);
        coinText.text = coinAmount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            score = player.transform.position.y;
            if (score > maxScore)
            {
                maxScore = score;
                scoreText.text = player.transform.position.y.ToString("F2") + " m";
            }
        }   
    }

    public void AddCoin(int amount)
    {
        coinAmount += amount;
        PlayerPrefs.SetInt("Coin", coinAmount);
        coinText.text = coinAmount.ToString();
    }

}
