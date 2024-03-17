using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public GameObject player;
    public Vector2 startPos;
    public GameManager gameManager;

    void Start()
    {

    }

    void Update()
    {
        if (player)
        {
            if (player.transform.position.y > transform.position.y + 5)
            {
                transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
            }

            if (player.transform.position.y < transform.position.y - 5)
            {
                gameManager.EndGame();
            }
        }
        
    }
}
