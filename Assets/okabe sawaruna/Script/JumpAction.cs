using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAction : MonoBehaviour
{
    [SerializeField] float _jumpPower = 10;
    [SerializeField] float _speed = 5;
    Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
           Jump();
        }
        float h = Input.GetAxisRaw("Horizontal");
        if (h != 0)
        {
            Vector2 dir = new Vector2(h, 0).normalized;
            _rb.velocity = dir * _speed;
        }
    }
    public void Jump()
    {
        _rb.AddForce(_jumpPower * Vector2.up, ForceMode2D.Impulse);
    }
}
