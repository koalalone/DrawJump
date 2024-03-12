using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float groundJumpForce = 5f;
    public float lineJumpForce = 10f;

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
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * groundJumpForce, ForceMode2D.Impulse);
        }

        if (collision.gameObject.tag == "Line")
        {
            //animator.SetTrigger("Jump");
            ContactPoint2D contact = collision.GetContact(0);
            GetComponent<Rigidbody2D>().AddForce(contact.normal * lineJumpForce, ForceMode2D.Impulse);
        }

        if (collision.gameObject.tag == "Side")
        {
            ContactPoint2D contact = collision.GetContact(0);
            GetComponent<Rigidbody2D>().AddForce(contact.normal, ForceMode2D.Impulse);
    }
    }
}
