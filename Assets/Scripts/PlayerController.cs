using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float jumpForce = 3f;

    public Animator animator;

    private void Update()
    {

        if (GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            //animator.SetTrigger("Fall");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            //animator.SetTrigger("Jump");
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (collision.gameObject.tag == "Side")
        {
            Vector2 speed = GetComponent<Rigidbody2D>().velocity;
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed.x, speed.y);
    }
    }
}
