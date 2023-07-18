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
        if(GetComponent<CircleCollider2D>().enabled == false)
        {
            _rb.rotation += 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            Destroy(this.gameObject);
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
        Destroy(this.gameObject);
    }

    public virtual void Move()
    {
        _rb.velocity = new Vector2(-1 * _moveSpeed, _rb.velocity.y);

    }
}
