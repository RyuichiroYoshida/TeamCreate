using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField, Header("älìæÉRÉCÉìêî")] int _coin;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.AddCoin(_coin);
            Destroy(gameObject);
        }
    }
}
