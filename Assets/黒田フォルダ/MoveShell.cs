using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShell : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float _moveSpeed;
    float _moveDirection;
    GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _rb = GetComponent<Rigidbody2D>();
        if(this.transform.position.x - _player.transform.position.x > 0)
        {
            _moveDirection = 1;
        }
        else
        {
            _moveDirection = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = new Vector2(_moveDirection * _moveSpeed, _rb.velocity.y);
    }
}
