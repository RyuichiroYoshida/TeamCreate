using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] Collider2D _goalCollision;

    private void Start()
    {
        _goalCollision = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _goalCollision.enabled = false;
            GameManager.instance.Goal();
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.Sleep();
            //rb.simulated = false;
        }
    }
}
