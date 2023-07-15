using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontMoveShell : Enemy
{
    Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(enemy.stompPrefub, this.transform.position, enemy.stompPrefub.transform.rotation);
            Destroy(this.gameObject);

        }
    }
}
