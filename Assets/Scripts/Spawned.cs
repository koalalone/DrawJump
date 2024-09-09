using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawned : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");

    }
    void Update()
    {
        if(transform.position.y < player.transform.position.y - 5f)
        {
            Destroy(gameObject);
        }
    }
}
