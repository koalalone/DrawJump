using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float scrollSpeed = 1f;
    public GameObject player;
    public Vector2 startPos;

    void Start()
    {
        
    }

    void Update()
    {
        if (player.transform.position.y > transform.position.y + 5)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }
    }
}
