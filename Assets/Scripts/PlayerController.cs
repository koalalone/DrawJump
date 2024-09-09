using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float groundJumpForce = 5f;
    private float lineJumpForce = 10f;
    private float rocketVelocity = 20f;
    
    public GameManager gameManager;
    public Score score;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.GetContact(0);
        switch (collision.gameObject.tag)
        {
            case "Ground":
                FindObjectOfType<AudioManager>().Play("Jump");
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * groundJumpForce, ForceMode2D.Impulse);
                break;
            case "Line":
                FindObjectOfType<AudioManager>().Play("Jump");
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
                FindObjectOfType<AudioManager>().Play("Bomb");
                Destroy(collision.gameObject);
                gameManager.EndGame();
                break;
            case "Rocket":
                FindObjectOfType<AudioManager>().Play("Rocket");
                GetComponent<Rigidbody2D>().velocity = Vector2.up * rocketVelocity;
                Destroy(collision.gameObject);
                break;
            case "Coin":
                FindObjectOfType<AudioManager>().Play("Coin");
                score.AddCoin(1);
                Destroy(collision.gameObject);
                break;
            default:
                break;
        }
    }           
}
