using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject _stompPrefub;
    [SerializeField] float _moveSpeed;
    

    Rigidbody2D _rb;
    //  å¸Ç´ïœçXóp
    Vector2 _moveDirection = new Vector2(-0.6f ,0);
    [SerializeField] LayerMask _wallLayer;



    public GameObject stompPrefub { get { return _stompPrefub; } }
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }
    private void FixedUpdate()
    {
        if (GetComponent<CircleCollider2D>() != null && GetComponent<CircleCollider2D>().enabled == false || GetComponent<BoxCollider2D>() != null && GetComponent<BoxCollider2D>().enabled == false)
        {
            _rb.rotation += 2;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Attack" || collision.gameObject.tag == "Player")
        {
            GameManager.instance.AddScore(1000);
            Destroy(this.gameObject);
        }
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Shell")
        {
            Direction();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Stomp();

        }
    }

    public virtual void Stomp()
    {
        Instantiate(_stompPrefub, this.transform.position, _stompPrefub.transform.rotation);
        GameManager.instance.AddScore(1000);
        Destroy(this.gameObject);
    }

    public virtual void Move()
    {
        Vector2 start = this.transform.position;
        Debug.DrawLine(start, start + _moveDirection);
        RaycastHit2D hitWall = Physics2D.Linecast(start , start + _moveDirection, _wallLayer);
        if (hitWall)
        {

            Direction();
        }
        _rb.velocity = new Vector2(_moveDirection.x * _moveSpeed, _rb.velocity.y);
    }

    private void Direction()
    {
        _moveDirection.x *= -1;
    }
}
