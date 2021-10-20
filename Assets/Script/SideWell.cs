using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWell : MonoBehaviour
{
    // Skrip GameManager untuk mengakses skor maksimal
    [SerializeField]
    public GameManager gameManager;

    // Pemain yang akan bertambah skornya jika bola menyentuh dinding ini
    public PlayerControl player;


    // Akan dipanggil ketika objek lain ber-collider (bola) bersentuhan dengan dinding
    void OnTriggerEnter2D(Collider2D anotherCollider)
    {
        // Jika objek tersebut bernama "Ball":
        if (anotherCollider.gameObject.name == "ball")
        {
            // Tambahkan skor ke pemain
            player.IncrementScore();

            // Jika skor pemain belum mencapai skor maksimal...  
            if (player.Score() < gameManager.MaxScore)
            {
                // ...dan restart game.
                anotherCollider.SendMessage("RestartGame", 2.0f, SendMessageOptions.RequireReceiver); 
            }          
        }
    }
}
