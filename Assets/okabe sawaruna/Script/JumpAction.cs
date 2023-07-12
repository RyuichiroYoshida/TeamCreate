using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAction : MonoBehaviour
{
    [SerializeField] float _jumpPower = 10;
    Rigidbody2D _rb;
    private string IsGroundTag = "IsGround";
    bool IsGround = false;

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == IsGroundTag)
        {
            IsGround = true;
        }
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && IsGround == true)
        {
           Jump();
        }
        
    }
    public void Jump()
    {
        IsGround = false;
        _rb.AddForce(_jumpPower * Vector2.up, ForceMode2D.Impulse);
    }
}
