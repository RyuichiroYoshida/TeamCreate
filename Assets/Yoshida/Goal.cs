using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.Goal();
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.Sleep();
            //rb.simulated = false;
        }
    }
}