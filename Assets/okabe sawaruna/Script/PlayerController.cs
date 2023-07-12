using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 5;
    Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if (h != 0)
        {
            Vector2 dir = new Vector2(h * _speed, _rb.velocity.y);
            _rb.velocity = dir;
        }
}
}
