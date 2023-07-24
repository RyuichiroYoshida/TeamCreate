using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class NotMoveShell : Enemy
{
    Enemy enemy;
    float _moveTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _moveTimer++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && _moveTimer > 20)
        {
            Instantiate(enemy.stompPrefub, this.transform.position, enemy.stompPrefub.transform.rotation);
            Destroy(this.gameObject);


        }

        if (collision.gameObject.tag == "Attack")
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && _moveTimer > 20)
        {
            Instantiate(enemy.stompPrefub, this.transform.position, enemy.stompPrefub.transform.rotation);
            Destroy(this.gameObject);

        }
    }

    public override void Stomp()
    {
        //Enemy‚ÌŠî’êƒNƒ‰ƒX‚Ì“¥‚Ü‚ê‚éˆ—‚ğ–³‹‚·‚é
    }
}
