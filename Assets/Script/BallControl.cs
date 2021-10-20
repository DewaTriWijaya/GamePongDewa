﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    // Rigidbody 2D bola
    private Rigidbody2D rigidBody2D;

    // Besarnya gaya awal yang diberikan untuk mendorong bola
    public float xInitialForce;
    public float yInitialForce;

    // Contoh tidak boleh di tiru
    // Gaya awal yg diberikan
    public float gaya = 100;

    private Vector2 trajectoryOrigin;

    // Untuk mangakses informasi titik asal lintasan
    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }


    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        trajectoryOrigin = transform.position;

        // Mulai game
        RestartGame();
    }


    void PushBall()
    {
        // Tentukan nilai komponen y dari gaya dorong antara -yInitialForce dan yInitialForce
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);

        // Tentukan nilai acak antara 0 (inklusif) dan 2 (eksklusif)
        float randomDirection = Random.Range(0, 2);

        // Contoh tidak untuk di tiru
        // komponen gaya dorong adlh hasil perhitungan vektor dari
        float x = Mathf.Sqrt(gaya * gaya - yRandomInitialForce * yRandomInitialForce);

        // Jika nilainya di bawah 1, bola bergerak ke kiri
        // Jika tidak, bola bergerak ke kanan
        if (randomDirection < 1.0f)
        {
            // Gunakan gaya untuk menggerakan bola ini
            rigidBody2D.AddForce(new Vector2(-x, yRandomInitialForce));
        }
        else
        {
            rigidBody2D.AddForce(new Vector2(x, yRandomInitialForce));
        }
    }


    // Ketika bola dari sebuah tumbukan, rekam titik tumbukan tersebut
    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }


    void ResetBall()
    {
        // Reset posisi menjadi (0,0)
        transform.position = Vector2.zero;

        // Reset kecepatan menjadi (0,0)
        rigidBody2D.velocity = Vector2.zero;
    }


    public void RestartGame()
    {
        // Kembalikan bola ke posisi semula
        ResetBall();

        // Setelah 2 detik, berikan gaya ke bola
        Invoke("PushBall", 2);
    }
}