using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public GameObject player;
    public Vector2 startPos;


    void FixedUpdate()
    {
        if (player)
        {
            if (player.transform.position.y > transform.position.y + 3.75)
            {
                transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
            }
        }
    }
}
