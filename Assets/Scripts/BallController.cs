using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    public float xInitialForce;
    public float yInitialForce;

    void ResetBall()
    {
        // Reset posisi
        transform.position = Vector2.zero;
        // Reset velocity
        rigidBody2D.velocity = Vector2.zero;
    }
    void PushBall()
    {
        // Nilai y
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);
        // Titik acak
        float randomDirection = Random.Range(0, 2);
        // Arah bola random
        if (randomDirection < 1.0f)
        {
            // Penggerak bola
            rigidBody2D.AddForce(new Vector2(-xInitialForce, yRandomInitialForce));
        }
        else
        {
            rigidBody2D.AddForce(new Vector2(xInitialForce, yRandomInitialForce));
        }
    }
    void RestartGame()
    {
        // Reset bola
        ResetBall();
        Invoke("PushBall", 2);
    }
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        // Memulai game
        RestartGame();
    }
}
