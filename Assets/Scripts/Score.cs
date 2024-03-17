using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject player;
    public Text scoreText;
    float maxScore = 0f;
    float score = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //scoreText.text = string.Empty;
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
}
