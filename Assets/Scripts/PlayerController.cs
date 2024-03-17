using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float groundJumpForce = 5f;
    public float lineJumpForce = 10f;
    
    public GameManager gameManager;
    public Animator animator;
    public Score score;

    private void Start()
    {

    }

    private void Update()
    {

        if (GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            //animator.SetTrigger("Fall");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.GetContact(0);
        switch (collision.gameObject.tag)
        {
            case "Ground":
                //animator.SetTrigger("Jump");
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * groundJumpForce, ForceMode2D.Impulse);
                break;
            case "Line":
                //animator.SetTrigger("Jump");
                GetComponent<Rigidbody2D>().AddForce(contact.normal * lineJumpForce, ForceMode2D.Impulse);
                break;
            case "Side":
                GetComponent<Rigidbody2D>().AddForce(contact.normal, ForceMode2D.Impulse);
                break;
            default:       
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Bomb":
                Destroy(collision.gameObject);
                gameManager.EndGame();
                break;
            case "Rocket":
                GetComponent<Rigidbody2D>().velocity = Vector2.up * 20f;
                Destroy(collision.gameObject);
                break;
            case "Coin":
                score.AddCoin(1);
                Destroy(collision.gameObject);
                break;
            default:
                break;
        }
    }           
}
