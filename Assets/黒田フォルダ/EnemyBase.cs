using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    /// <summary>
    /// ƒ_ƒ[ƒW‚ğó‚¯‚½‚Ìˆ—
    /// </summary>

    public abstract void Stomp();
    public abstract void PlayerAttack();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Stomp();

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            PlayerAttack();
        }
    }
}
