using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    float height;

    // Update is called once per frame
    void Update()
    {
        height = player.transform.position.y;
        if (height > transform.position.y & height > 1f)
        {
                Vector3 desiredPosition = new Vector3(transform.position.x, player.position.y, transform.position.z);
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
                transform.position = smoothedPosition;
        }    
    }
}
