using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Tombol untuk menggerakan ke atas 
    public KeyCode upButton = KeyCode.W;

    // Tombol untuk menggerakan ke bawah
    public KeyCode downButton = KeyCode.S;

    // Kecepatan gerak
    public float speed = 10.0f;

    // Batas atas dan bawah game scane (Batas bawah menggunakan minus (-))
    public float yBoundary = 9.0f;

    // Rigibody 2D raket ini
    private Rigidbody2D rigidBody2D;

    // Skor pemain
    private int score;

    // Titik tumbukan terakhir dengan bola, untuk menampilkan variabel2 fisika terkait tumbukan tersebut
    private ContactPoint2D lastContactPoint;


    // Untuk mengakses informasi titik dari kelas lain
    public ContactPoint2D LastContactPoint
    {
        get { return lastContactPoint; }
    }


    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        // Dapatkan kecepatan raket sekarang
        Vector2 velocity = rigidBody2D.velocity;

        // Jika pemain menekan tombol ke atas, beri kecepatan positif ke komponen y (ke atas)
        if (Input.GetKey(upButton))
        {
            velocity.y = speed;
        }

        // Jika pemain menekan tombol ke bawah, beri kecepatan negatyif ke komponen y (ke bawah
        else if (Input.GetKey(downButton))
        {
            velocity.y = -speed;
        }

        // Jika pemain tidak menekan tombol apa-apa, kecepatan nol
        else
        {
            velocity.y = 0.0f;
        }

        // Masukan kembali kecepatannya ke rigiBody2D
        rigidBody2D.velocity = velocity;

        // Dapatkan posisi raket sekarang
        Vector3 position = transform.position;

        // Jika posisi raket melewati batas atas (yBoundary), kembalikan ke batas ats tersebut
        if (position.y > yBoundary)
        {
            position.y = yBoundary;
        }

        // Jika posisi raket melewati batas bawah (-yBoundary), kembalikan ke batas atas tersebut
        else if (position.y < -yBoundary)
        {
            position.y = -yBoundary;
        }

        // Masukan kembali posisinya ke transform 
        transform.position = position;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("ball"))
        {
            lastContactPoint = collision.GetContact(0);
        }
    }


    // Menaikan skor sebanyak 1 poin
    public void IncrementScore()
    {
        score++;
    }

    // Mengembalikan skor menjadi 0
    public void ResetScore()
    {
        score = 0;
    }

    // Mendapatkan nilai skor 
    public int Score()
    {
        return score; 
    }
}

